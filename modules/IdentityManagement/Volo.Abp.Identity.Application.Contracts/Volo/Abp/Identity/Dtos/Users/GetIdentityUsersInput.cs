using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity.Dtos.Users;

public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 过滤
    /// </summary>
    public string Filter { get; set; }
}