using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TenantManagement.Dtos;

public class TenantUpdateDto : TenantCreateOrUpdateDtoBase, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
