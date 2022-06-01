using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Identity.Dtos.Roles;

public class IdentityRoleUpdateDto : IdentityRoleCreateOrUpdateDtoBase, IHasConcurrencyStamp
{
    /// <summary>
    /// 并发时间戳
    /// </summary>
    public string ConcurrencyStamp { get; set; }
}