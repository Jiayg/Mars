using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement.Dtos;

namespace Volo.Abp.SettingManagement.Services;

public interface IEmailSettingsAppService : IApplicationService
{
    /// <summary>
    /// 查询邮箱设置
    /// </summary>
    /// <returns></returns>
    Task<EmailSettingsDto> GetAsync();

    /// <summary>
    /// 更新邮箱设置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync(UpdateEmailSettingsDto input);

    /// <summary>
    /// 发送测试邮件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task SendTestEmailAsync(SendTestEmailInput input);
}