using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Account.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Account;

[RemoteService(Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Area(AccountRemoteServiceConsts.ModuleName)]
[ControllerName("Profile")]
[Route("/api/account/my-profile")]
public class ProfileController : AbpControllerBase, IProfileAppService
{
    private readonly IProfileAppService _profileAppService;

    public ProfileController(IProfileAppService profileAppService)
    {
        _profileAppService = profileAppService;
    }

    /// <summary>
    /// 查询用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public virtual Task<ProfileDto> GetAsync()
    {
        return _profileAppService.GetAsync();
    }

    /// <summary>
    /// 修改用户信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    public virtual Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
    {
        return _profileAppService.UpdateAsync(input);
    }

    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("change-password")]
    public virtual Task ChangePasswordAsync(ChangePasswordInput input)
    {
        return _profileAppService.ChangePasswordAsync(input);
    }
}