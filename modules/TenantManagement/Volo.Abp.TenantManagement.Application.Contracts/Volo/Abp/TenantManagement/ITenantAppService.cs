using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.TenantManagement;

public interface ITenantAppService : IApplicationService
{
    Task<TenantDto> GetAsync(Guid id);

    Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input);

    Task<TenantDto> CreateAsync(TenantCreateDto input);

    Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input);

    Task DeleteAsync(Guid id);

    Task<string> GetDefaultConnectionStringAsync(Guid id);

    Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString);

    Task DeleteDefaultConnectionStringAsync(Guid id);
}
