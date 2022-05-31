using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement.Dtos;

public class GetTenantsInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
