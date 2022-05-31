using System.ComponentModel.DataAnnotations;

namespace Volo.Abp.Identity.Dtos.Users;

public class IdentityUserUpdateRolesDto
{
    [Required]
    public string[] RoleNames { get; set; }
}
