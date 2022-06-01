using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.SettingManagement.Dtos;
using Volo.Abp.SettingManagement.Permissions;
using Volo.Abp.SettingManagement.Services;

namespace Volo.Abp.SettingManagement;

[RemoteService(Name = SettingManagementRemoteServiceConsts.RemoteServiceName)]
[Area(SettingManagementRemoteServiceConsts.ModuleName)]
[Route("api/setting-management/emailing")]
public class EmailSettingsController : AbpControllerBase, IEmailSettingsAppService
{
    private readonly IEmailSettingsAppService _emailSettingsAppService;

    public EmailSettingsController(IEmailSettingsAppService emailSettingsAppService)
    {
        _emailSettingsAppService = emailSettingsAppService;
    }

    /// <summary>
    /// 查询邮箱设置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<EmailSettingsDto> GetAsync()
    {
        return _emailSettingsAppService.GetAsync();
    }

    /// <summary>
    /// 更新邮箱设置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task UpdateAsync(UpdateEmailSettingsDto input)
    {
        return _emailSettingsAppService.UpdateAsync(input);
    }

    /// <summary>
    /// 发送测试邮件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("send-test-email")]
    [Authorize(SettingManagementPermissions.EmailingTest)]
    public Task SendTestEmailAsync(SendTestEmailInput input)
    {
        return _emailSettingsAppService.SendTestEmailAsync(input);
    }
}