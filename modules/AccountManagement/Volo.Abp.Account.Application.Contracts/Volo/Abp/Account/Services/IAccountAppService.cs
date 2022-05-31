using System.Threading.Tasks;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity.Dtos.Users;

namespace Volo.Abp.Account.Services;

public interface IAccountAppService : IApplicationService
{
    Task<IdentityUserDto> RegisterAsync(RegisterDto input);

    Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input);

    Task ResetPasswordAsync(ResetPasswordDto input);
}