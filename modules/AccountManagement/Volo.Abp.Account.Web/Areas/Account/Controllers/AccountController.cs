using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Volo.Abp.Account.Localization;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web.Areas.Account.Controllers.Models;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using UserLoginInfo = Volo.Abp.Account.Web.Areas.Account.Controllers.Models.UserLoginInfo;

namespace Volo.Abp.Account.Web.Areas.Account.Controllers;

[RemoteService(Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Controller]
[ControllerName("Login")]
[Area("account")]
[Route("api/account")]
public class AccountController : AbpControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<IdentityUser, Guid> _userRepository;

    protected SignInManager<IdentityUser> SignInManager { get; }
    protected IdentityUserManager UserManager { get; }
    protected ISettingProvider SettingProvider { get; }
    protected IdentitySecurityLogManager IdentitySecurityLogManager { get; }
    protected IOptions<IdentityOptions> IdentityOptions { get; }

    public AccountController(
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            ICurrentTenant currentTenant,
            IRepository<IdentityUser, Guid> userRepository,
            SignInManager<IdentityUser> signInManager,
            IdentityUserManager userManager,
            ISettingProvider settingProvider,
            IdentitySecurityLogManager identitySecurityLogManager,
            IOptions<IdentityOptions> identityOptions)
    {
        LocalizationResource = typeof(AccountResource);
        _httpContextAccessor = httpContextAccessor;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _currentTenant = currentTenant;
        _userRepository = userRepository;
        SignInManager = signInManager;
        UserManager = userManager;
        SettingProvider = settingProvider;
        IdentitySecurityLogManager = identitySecurityLogManager;
        IdentityOptions = identityOptions;
    }

    [HttpPost]
    [Route("login")]
    public virtual async Task<AbpLoginResult> Login(UserLoginInfo login)
    {
        await CheckLocalLoginAsync();

        ValidateLoginInfo(login);

        await ReplaceEmailToUsernameOfInputIfNeeds(login);
        var signInResult = await SignInManager.PasswordSignInAsync(
            login.UserNameOrEmailAddress,
            login.Password,
            login.RememberMe,
            true
        );

        await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
        {
            Identity = IdentitySecurityLogIdentityConsts.Identity,
            Action = signInResult.ToIdentitySecurityLogAction(),
            UserName = login.UserNameOrEmailAddress
        });

        return GetAbpLoginResult(signInResult);
    }

    [HttpGet]
    [Route("logout")]
    public virtual async Task Logout()
    {
        await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
        {
            Identity = IdentitySecurityLogIdentityConsts.Identity,
            Action = IdentitySecurityLogActionConsts.Logout
        });

        await SignInManager.SignOutAsync();
    }

    [HttpPost]
    [Route("checkPassword")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual Task<AbpLoginResult> CheckPasswordCompatible(UserLoginInfo login)
    {
        return CheckPassword(login);
    }

    [HttpPost]
    [Route("check-password")]
    public virtual async Task<AbpLoginResult> CheckPassword(UserLoginInfo login)
    {
        ValidateLoginInfo(login);

        await ReplaceEmailToUsernameOfInputIfNeeds(login);

        var identityUser = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress);

        if (identityUser == null)
        {
            return new AbpLoginResult(LoginResultType.InvalidUserNameOrPassword);
        }

        await IdentityOptions.SetAsync();
        return GetAbpLoginResult(await SignInManager.CheckPasswordSignInAsync(identityUser, login.Password, true));
    }

    [HttpPost]
    [Route("localLogin")]
    public virtual async Task<LocalLoginResult> LocalLogin(LocalLoginInfo login)
    {
        ValidateLocalLoginInfo(login);

        //客户端ip
        var customerIp = getCustomerIp();
        if (!LimitAccount(customerIp))
            throw new UserFriendlyException($"IP：{customerIp}不在白名单中");

        var user = await UserManager.FindByNameAsync(login.Username); //根据用户名获取用户
        if (user == null)
            throw new UserFriendlyException("账号或密码错误");

        var userModel = await _userRepository.FindAsync(user.Id);
        //if (userModel.IsStop == 1)
        //    throw new UserFriendlyException("账号已被停用");

        var client = _httpClientFactory.CreateClient();
        var dic = new Dictionary<string, object>
            {
                {"grant_type",login.Grant_type },
                {"scope",login.Scope },
                {"username",login.Username },
                {"password",login.Password },
                {"client_id",login.Client_id },
                {"client_secret",login.Client_secret }
            };

        var dic_str = dic.Select(m => m.Key + "=" + m.Value).DefaultIfEmpty().Aggregate((m, n) => m + "&" + n);

        var httpContent = new StringContent(dic_str);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        var oauth_rep = await client.PostAsync(login.LoginUrl, httpContent);
        var oauth_str = await oauth_rep.Content.ReadAsStringAsync();
        var oauth_job = JsonConvert.DeserializeObject<JObject>(oauth_str);
        if (!oauth_job.ContainsKey("error"))
        {
            //记录登录日志
            //await _loginLogsRepository.InsertAsync(new LoginLogs()
            //{
            //    UserId = user.Id,
            //    UserName = user.UserName,
            //    IpAddress = customerIp,
            //    EquipmentName = GetUserAgent()
            //});
        }
        else
        {
            //_logger.LogError($"独立登录失败：{oauth_str}");
            var getResult = oauth_job.TryGetValue("error_description", out JToken error_msg);
            if (getResult)
                throw new UserFriendlyException("账号或密码错误");  // throw new UserFriendlyException(error_msg.ToString());
            else
                throw new UserFriendlyException("登录失败");
        }

        return JsonConvert.DeserializeObject<LocalLoginResult>(oauth_str);
    }

    #region 私有方法

    protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds(UserLoginInfo login)
    {
        if (!ValidationHelper.IsValidEmailAddress(login.UserNameOrEmailAddress))
        {
            return;
        }

        var userByUsername = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress);
        if (userByUsername != null)
        {
            return;
        }

        var userByEmail = await UserManager.FindByEmailAsync(login.UserNameOrEmailAddress);
        if (userByEmail == null)
        {
            return;
        }

        login.UserNameOrEmailAddress = userByEmail.UserName;
    }

    private static AbpLoginResult GetAbpLoginResult(SignInResult result)
    {
        if (result.IsLockedOut)
        {
            return new AbpLoginResult(LoginResultType.LockedOut);
        }

        if (result.RequiresTwoFactor)
        {
            return new AbpLoginResult(LoginResultType.RequiresTwoFactor);
        }

        if (result.IsNotAllowed)
        {
            return new AbpLoginResult(LoginResultType.NotAllowed);
        }

        if (!result.Succeeded)
        {
            return new AbpLoginResult(LoginResultType.InvalidUserNameOrPassword);
        }

        return new AbpLoginResult(LoginResultType.Success);
    }

    protected virtual void ValidateLoginInfo(UserLoginInfo login)
    {
        if (login == null)
        {
            throw new ArgumentException(nameof(login));
        }

        if (login.UserNameOrEmailAddress.IsNullOrEmpty())
        {
            throw new ArgumentNullException(nameof(login.UserNameOrEmailAddress));
        }

        if (login.Password.IsNullOrEmpty())
        {
            throw new ArgumentNullException(nameof(login.Password));
        }
    }

    protected virtual void ValidateLocalLoginInfo(LocalLoginInfo login)
    {
        if (login == null)
            throw new ArgumentException(nameof(login));

        if (login.LoginUrl.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.LoginUrl));

        if (login.Username.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.Username));
        if (login.Password.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.Password));
        if (login.Scope.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.Scope));
        if (login.Grant_type.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.Grant_type));
        if (login.Client_id.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.Client_id));
        if (login.Client_secret.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(login.Client_secret));
    }

    protected virtual async Task CheckLocalLoginAsync()
    {
        if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
        {
            throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
        }
    }

    /// <summary>
    /// 登录设备
    /// </summary>
    /// <returns></returns>
    private string getUserAgent()
    {
        return _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].FirstOrDefault();
    }

    /// <summary>
    /// 客户端IP地址
    /// </summary>
    /// <returns></returns>
    private string getCustomerIp()
    {
        var ip = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (string.IsNullOrEmpty(ip))
        {
            ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        return ip;
    }

    /// <summary>
    /// 限制指定租户在指定ip下可登录
    /// </summary>
    /// <returns></returns>
    private bool LimitAccount(string customerIp)
    {
        var limitConfig = _configuration.GetSection("LimitConfig");

        if (!limitConfig.Exists())
            return true;

        //var limitAccount = limitConfig.GetValue<string>("Account"); //要限制的账号
        //if (string.IsNullOrEmpty(limitAccount)) return true;
        //var limitAccountArray = limitAccount.Split(',').ToList();
        //if (!limitAccountArray.Any(p => string.Equals(p, account, StringComparison.CurrentCultureIgnoreCase)))
        //    return true;

        if (string.IsNullOrEmpty(_currentTenant.Name))
            return true;

        //要限制的租户
        var limitTenant = limitConfig.GetValue<string>("Tenant");
        if (string.IsNullOrEmpty(limitTenant))
            return true;

        var limitTenantArray = limitTenant.Split(',').ToList();
        if (!limitTenantArray.Contains(_currentTenant.Name))
            return true;

        var allowIp = limitConfig.GetValue<string>("AllowIp"); //允许访问的ip
        if (string.IsNullOrEmpty(allowIp))
            return true;

        var allowIpArray = allowIp.Split(',').ToList();
        return allowIpArray.Contains(customerIp);
    }

    #endregion 私有方法
}