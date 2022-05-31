using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Identity;

[RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
[Area(IdentityRemoteServiceConsts.ModuleName)]
[ControllerName("Role")]
[Route("api/identity/roles")]
public class IdentityRoleController : AbpControllerBase, IIdentityRoleAppService
{
    private readonly IIdentityRoleAppService _roleAppService;

    public IdentityRoleController(IIdentityRoleAppService roleAppService)
    {
        _roleAppService = roleAppService;
    }

    [HttpGet]
    [Route("all")]
    public virtual Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
    {
        return _roleAppService.GetAllListAsync();
    }

    [HttpGet]
    public virtual Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRolesInput input)
    {
        return _roleAppService.GetListAsync(input);
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<IdentityRoleDto> GetAsync(Guid id)
    {
        return _roleAppService.GetAsync(id);
    }

    [HttpPost]
    [Authorize(IdentityPermissions.Roles.Create)]
    public virtual Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
    {
        return _roleAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(IdentityPermissions.Roles.Update)]
    public virtual Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
    {
        return _roleAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(IdentityPermissions.Roles.Delete)]
    public virtual Task DeleteAsync(Guid id)
    {
        return _roleAppService.DeleteAsync(id);
    }
}
