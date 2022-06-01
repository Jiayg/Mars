using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Dtos.Roles;

public class GetIdentityRolesInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 过滤
    /// </summary>
    public string Filter { get; set; }
}