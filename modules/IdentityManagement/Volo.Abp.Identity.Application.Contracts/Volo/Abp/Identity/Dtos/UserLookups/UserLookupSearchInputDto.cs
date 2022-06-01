using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Dtos.UserLookups;

public class UserLookupSearchInputDto : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 过滤
    /// </summary>
    public string Filter { get; set; }
}