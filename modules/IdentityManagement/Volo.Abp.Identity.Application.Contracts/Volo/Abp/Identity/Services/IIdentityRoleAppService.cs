using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity.Dtos.Roles;

namespace Volo.Abp.Identity.Services;

public interface IIdentityRoleAppService : IApplicationService
{
    /// <summary>
    /// 查询角色
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IdentityRoleDto> GetAsync(Guid id);

    /// <summary>
    /// 查询角色列表
    /// </summary>
    /// <returns></returns>
    Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();

    /// <summary>
    /// 查询角色分页列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRolesInput input);

    /// <summary>
    /// 添加角色
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input);

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);
}