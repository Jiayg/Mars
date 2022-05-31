// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System.Threading.Tasks;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Account.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.Abp.Identity.Dtos.Users;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.Account.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IAccountAppService), typeof(AccountClientProxy))]
public partial class AccountClientProxy : ClientProxyBase<IAccountAppService>, IAccountAppService
{
    public virtual async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
    {
        return await RequestAsync<IdentityUserDto>(nameof(RegisterAsync), new ClientProxyRequestTypeValue
        {
            { typeof(RegisterDto), input }
        });
    }

    public virtual async Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
    {
        await RequestAsync(nameof(SendPasswordResetCodeAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SendPasswordResetCodeDto), input }
        });
    }

    public virtual async Task ResetPasswordAsync(ResetPasswordDto input)
    {
        await RequestAsync(nameof(ResetPasswordAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ResetPasswordDto), input }
        });
    }
}