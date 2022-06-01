using System.Threading.Tasks;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity.Dtos.Users;

namespace Volo.Abp.Account.Services;

public interface IAccountAppService : IApplicationService
{
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<IdentityUserDto> RegisterAsync(RegisterDto input);

    /// <summary>
    /// 发送重置密码code
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input);

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task ResetPasswordAsync(ResetPasswordDto input);
}