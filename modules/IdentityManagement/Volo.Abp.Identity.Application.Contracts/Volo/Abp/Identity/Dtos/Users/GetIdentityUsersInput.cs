using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Dtos.Users;

public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
