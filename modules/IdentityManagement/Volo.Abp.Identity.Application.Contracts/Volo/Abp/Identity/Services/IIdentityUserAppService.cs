using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity.Dtos.Roles;
using Volo.Abp.Identity.Dtos.Users;

namespace Volo.Abp.Identity.Services;

public interface IIdentityUserAppService : IApplicationService
{
    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IdentityUserDto> GetAsync(Guid id);

    /// <summary>
    /// 查询用户列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input);

    /// <summary>
    /// 查询用户角色列表
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);

    /// <summary>
    /// 查询可分配用户角色
    /// </summary>
    /// <returns></returns>
    Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync();

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input);

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// 修改用户角色
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

    /// <summary>
    /// 根据用户名查询用户
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<IdentityUserDto> FindByUserNameAsync(string userName);

    /// <summary>
    /// 根据用户邮箱查询用户
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<IdentityUserDto> FindByEmailAsync(string email);
}