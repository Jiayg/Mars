using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Dtos.Roles;

public class GetIdentityRolesInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
