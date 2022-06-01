using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement.Dtos;

public class GetTenantsInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 过滤
    /// </summary>
    public string Filter { get; set; }
}