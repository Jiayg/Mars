﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.PermissionManagement;

[RemoteService(Name = PermissionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(PermissionManagementRemoteServiceConsts.ModuleName)]
[Route("api/permission-management/permissions")]
public class PermissionsController : AbpControllerBase, IPermissionAppService
{
    private readonly IPermissionAppService _permissionAppService;

    public PermissionsController(IPermissionAppService permissionAppService)
    {
        this._permissionAppService = permissionAppService;
    }

    [HttpGet]
    public virtual Task<GetPermissionListResultDto> GetAsync(string providerName, string providerKey)
    {
        return _permissionAppService.GetAsync(providerName, providerKey);
    }

    [HttpPut]
    public virtual Task UpdateAsync(string providerName, string providerKey, UpdatePermissionsDto input)
    {
        return _permissionAppService.UpdateAsync(providerName, providerKey, input);
    }
}
