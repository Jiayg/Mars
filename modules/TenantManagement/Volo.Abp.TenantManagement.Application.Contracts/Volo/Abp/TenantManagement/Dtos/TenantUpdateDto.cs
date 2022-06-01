using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TenantManagement.Dtos;

public class TenantUpdateDto : TenantCreateOrUpdateDtoBase, IHasConcurrencyStamp
{
    /// <summary>
    /// 并发时间戳
    /// </summary>
    public string ConcurrencyStamp { get; set; }
}