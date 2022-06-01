using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement.Dtos;

namespace Volo.Abp.TenantManagement.Services;

public interface ITenantAppService : IApplicationService
{
    /// <summary>
    /// 根据id查询租户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TenantDto> GetAsync(Guid id);

    /// <summary>
    /// 分页查询租户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input);

    /// <summary>
    /// 添加租户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<TenantDto> CreateAsync(TenantCreateDto input);

    /// <summary>
    /// 修改租户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input);

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// 根据id查询租户的数据库链接字符串
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<string> GetDefaultConnectionStringAsync(Guid id);

    /// <summary>
    /// 修改租户的数据库链接字符串
    /// </summary>
    /// <param name="id"></param>
    /// <param name="defaultConnectionString"></param>
    /// <returns></returns>
    Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString);

    /// <summary>
    /// 删除租户的数据库链接字符串
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteDefaultConnectionStringAsync(Guid id);
}