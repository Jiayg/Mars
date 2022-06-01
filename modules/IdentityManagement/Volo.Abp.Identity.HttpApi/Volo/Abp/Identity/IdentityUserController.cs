using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity.Dtos.Roles;
using Volo.Abp.Identity.Dtos.Users;
using Volo.Abp.Identity.Permissions;
using Volo.Abp.Identity.Services;

namespace Volo.Abp.Identity;

[RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
[Area(IdentityRemoteServiceConsts.ModuleName)]
[ControllerName("User")]
[Route("api/identity/users")]
public class IdentityUserController : AbpControllerBase, IIdentityUserAppService
{
    private readonly IIdentityUserAppService _userAppService;

    public IdentityUserController(IIdentityUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [Authorize(IdentityPermissions.Users.Default)]
    public virtual Task<IdentityUserDto> GetAsync(Guid id)
    {
        return _userAppService.GetAsync(id);
    }

    /// <summary>
    /// 查询用户列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize(IdentityPermissions.Users.Default)]
    public virtual Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
    {
        return _userAppService.GetListAsync(input);
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(IdentityPermissions.Users.Create)]
    public virtual Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
    {
        return _userAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    [Authorize(IdentityPermissions.Users.Update)]
    public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
    {
        return _userAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [Authorize(IdentityPermissions.Users.Delete)]
    public virtual Task DeleteAsync(Guid id)
    {
        return _userAppService.DeleteAsync(id);
    }

    /// <summary>
    /// 查询用户角色列表
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}/roles")]
    [Authorize(IdentityPermissions.Users.Default)]
    public virtual Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
    {
        return _userAppService.GetRolesAsync(id);
    }

    /// <summary>
    /// 查询可分配用户角色
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("assignable-roles")]
    [Authorize(IdentityPermissions.Users.Default)]
    public Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
    {
        return _userAppService.GetAssignableRolesAsync();
    }

    /// <summary>
    /// 修改用户角色
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}/roles")]
    [Authorize(IdentityPermissions.Users.Update)]
    public virtual Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
    {
        return _userAppService.UpdateRolesAsync(id, input);
    }

    /// <summary>
    /// 根据用户名查询用户
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("by-username/{userName}")]
    [Authorize(IdentityPermissions.Users.Default)]
    public virtual Task<IdentityUserDto> FindByUserNameAsync(string userName)
    {
        return _userAppService.FindByUserNameAsync(userName);
    }

    /// <summary>
    /// 根据用户邮箱查询用户
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("by-email/{email}")]
    [Authorize(IdentityPermissions.Users.Default)]
    public virtual Task<IdentityUserDto> FindByEmailAsync(string email)
    {
        return _userAppService.FindByEmailAsync(email);
    }
}