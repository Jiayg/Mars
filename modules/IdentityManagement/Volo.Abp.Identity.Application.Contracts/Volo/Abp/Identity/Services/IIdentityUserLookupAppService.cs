using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity.Dtos.UserLookups;
using Volo.Abp.Users;

namespace Volo.Abp.Identity.Services;

public interface IIdentityUserLookupAppService : IApplicationService
{
    /// <summary>
    /// 查找用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserData> FindByIdAsync(Guid id);

    /// <summary>
    /// 根据用户名查找用户
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<UserData> FindByUserNameAsync(string userName);

    /// <summary>
    /// 根据条件查找用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ListResultDto<UserData>> SearchAsync(UserLookupSearchInputDto input);

    /// <summary>
    /// 查找用户数量
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<long> GetCountAsync(UserLookupCountInputDto input);
}