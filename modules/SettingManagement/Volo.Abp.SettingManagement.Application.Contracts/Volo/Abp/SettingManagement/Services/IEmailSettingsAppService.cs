using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement.Dtos;

namespace Volo.Abp.SettingManagement.Services;

public interface IEmailSettingsAppService : IApplicationService
{
    Task<EmailSettingsDto> GetAsync();

    Task UpdateAsync(UpdateEmailSettingsDto input);

    Task SendTestEmailAsync(SendTestEmailInput input);
}
