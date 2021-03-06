// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System.Threading.Tasks;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Account.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;

// ReSharper disable once CheckNamespace
namespace Volo.Abp.Account.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IProfileAppService), typeof(ProfileClientProxy))]
public partial class ProfileClientProxy : ClientProxyBase<IProfileAppService>, IProfileAppService
{
    public virtual async Task<ProfileDto> GetAsync()
    {
        return await RequestAsync<ProfileDto>(nameof(GetAsync));
    }

    public virtual async Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
    {
        return await RequestAsync<ProfileDto>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(UpdateProfileDto), input }
        });
    }

    public virtual async Task ChangePasswordAsync(ChangePasswordInput input)
    {
        await RequestAsync(nameof(ChangePasswordAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ChangePasswordInput), input }
        });
    }
}