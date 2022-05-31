﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity.Dtos.Roles;
using Volo.Abp.Identity.Dtos.Users;

namespace Volo.Abp.Identity.Services;

public interface IIdentityUserAppService : IApplicationService
{
    Task<IdentityUserDto> GetAsync(Guid id);

    Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input);

    Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);

    Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync();

    Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input);

    Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input);

    Task DeleteAsync(Guid id);

    Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

    Task<IdentityUserDto> FindByUserNameAsync(string userName);

    Task<IdentityUserDto> FindByEmailAsync(string email);
}