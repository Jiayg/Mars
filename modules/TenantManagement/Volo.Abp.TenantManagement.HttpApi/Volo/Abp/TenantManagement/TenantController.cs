using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.TenantManagement.Dtos;
using Volo.Abp.TenantManagement.Permissions;
using Volo.Abp.TenantManagement.Services;

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

    /// <summary>
    /// 查询租户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public virtual Task<TenantDto> GetAsync(Guid id)
    {
        return _tenantAppService.GetAsync(id);
    }

    /// <summary>
    /// 查询租户分页列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        return _tenantAppService.GetListAsync(input);
    }

    /// <summary>
    /// 添加租户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public virtual Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        ValidateModel();
        return _tenantAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    [Authorize(TenantManagementPermissions.Tenants.Update)]
    public virtual Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    {
        return _tenantAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [Authorize(TenantManagementPermissions.Tenants.Delete)]
    public virtual Task DeleteAsync(Guid id)
    {
        return _tenantAppService.DeleteAsync(id);
    }

    /// <summary>
    /// 查询租户数据库链接字符串
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}/default-connection-string")]
    [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
    public virtual Task<string> GetDefaultConnectionStringAsync(Guid id)
    {
        return _tenantAppService.GetDefaultConnectionStringAsync(id);
    }

    /// <summary>
    /// 更新租户数据库链接字符串
    /// </summary>
    /// <param name="id"></param>
    /// <param name="defaultConnectionString"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}/default-connection-string")]
    [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
    public virtual Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
    {
        return _tenantAppService.UpdateDefaultConnectionStringAsync(id, defaultConnectionString);
    }

    /// <summary>
    /// 删除租户数据库链接字符串
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}/default-connection-string")]
    [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
    public virtual Task DeleteDefaultConnectionStringAsync(Guid id)
    {
        return _tenantAppService.DeleteDefaultConnectionStringAsync(id);
    }
}