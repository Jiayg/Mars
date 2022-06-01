using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity.Dtos.UserLookups;
using Volo.Abp.Identity.Services;
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

    /// <summary>
    /// 查找用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public virtual Task<UserData> FindByIdAsync(Guid id)
    {
        return _lookupAppService.FindByIdAsync(id);
    }

    /// <summary>
    /// 根据用户名查找用户
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("by-username/{userName}")]
    public virtual Task<UserData> FindByUserNameAsync(string userName)
    {
        return _lookupAppService.FindByUserNameAsync(userName);
    }

    /// <summary>
    /// 根据条件查找用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("search")]
    public Task<ListResultDto<UserData>> SearchAsync(UserLookupSearchInputDto input)
    {
        return _lookupAppService.SearchAsync(input);
    }

    /// <summary>
    /// 查找用户数量
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("count")]
    public Task<long> GetCountAsync(UserLookupCountInputDto input)
    {
        return _lookupAppService.GetCountAsync(input);
    }
}