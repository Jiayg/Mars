using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Dtos.UserLookups;

public class UserLookupSearchInputDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
