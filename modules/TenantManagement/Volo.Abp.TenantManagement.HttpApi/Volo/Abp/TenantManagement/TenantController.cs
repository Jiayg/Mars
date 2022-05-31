using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.TenantManagement;

[Controller]
[RemoteService(Name = TenantManagementRemoteServiceConsts.RemoteServiceName)]
[Area(TenantManagementRemoteServiceConsts.ModuleName)]
[Route("api/multi-tenancy/tenants")]
public class TenantController : AbpControllerBase, ITenantAppService //TODO: Throws exception on validation if we inherit from Controller
{
    private readonly ITenantAppService _tenantAppService;

    public TenantController(ITenantAppService tenantAppService)
    {
        _tenantAppService = tenantAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<TenantDto> GetAsync(Guid id)
    {
        return _tenantAppService.GetAsync(id);
    }

    [HttpGet]
    public virtual Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        return _tenantAppService.GetListAsync(input);
    }

    [HttpPost]
    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public virtual Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        ValidateModel();
        return _tenantAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(TenantManagementPermissions.Tenants.Update)]
    public virtual Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    {
        return _tenantAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(TenantManagementPermissions.Tenants.Delete)]
    public virtual Task DeleteAsync(Guid id)
    {
        return _tenantAppService.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id}/default-connection-string")]
    [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
    public virtual Task<string> GetDefaultConnectionStringAsync(Guid id)
    {
        return _tenantAppService.GetDefaultConnectionStringAsync(id);
    }

    [HttpPut]
    [Route("{id}/default-connection-string")]
    [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
    public virtual Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
    {
        return _tenantAppService.UpdateDefaultConnectionStringAsync(id, defaultConnectionString);
    }

    [HttpDelete]
    [Route("{id}/default-connection-string")]
    [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
    public virtual Task DeleteDefaultConnectionStringAsync(Guid id)
    {
        return _tenantAppService.DeleteDefaultConnectionStringAsync(id);
    }
}
