using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Identity.Dtos.Roles;

public class IdentityRoleUpdateDto : IdentityRoleCreateOrUpdateDtoBase, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
