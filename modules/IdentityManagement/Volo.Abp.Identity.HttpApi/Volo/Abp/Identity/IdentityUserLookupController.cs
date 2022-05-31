using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Volo.Abp.Identity;

[RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
[Area(IdentityRemoteServiceConsts.ModuleName)]
[ControllerName("UserLookup")]
[Route("api/identity/users/lookup")]
public class IdentityUserLookupController : AbpControllerBase, IIdentityUserLookupAppService
{
    private readonly IIdentityUserLookupAppService _lookupAppService;

    public IdentityUserLookupController(IIdentityUserLookupAppService lookupAppService)
    {
        _lookupAppService = lookupAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<UserData> FindByIdAsync(Guid id)
    {
        return _lookupAppService.FindByIdAsync(id);
    }

    [HttpGet]
    [Route("by-username/{userName}")]
    public virtual Task<UserData> FindByUserNameAsync(string userName)
    {
        return _lookupAppService.FindByUserNameAsync(userName);
    }

    [HttpGet]
    [Route("search")]
    public Task<ListResultDto<UserData>> SearchAsync(UserLookupSearchInputDto input)
    {
        return _lookupAppService.SearchAsync(input);
    }

    [HttpGet]
    [Route("count")]
    public Task<long> GetCountAsync(UserLookupCountInputDto input)
    {
        return _lookupAppService.GetCountAsync(input);
    }
}
