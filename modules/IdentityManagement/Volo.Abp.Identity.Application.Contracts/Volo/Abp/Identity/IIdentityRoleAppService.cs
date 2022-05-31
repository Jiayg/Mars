﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.Identity;

public interface IIdentityRoleAppService : IApplicationService
{
    Task<IdentityRoleDto> GetAsync(Guid id);

    Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();

    Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRolesInput input);

    Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);

    Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input);

    Task DeleteAsync(Guid id);
}