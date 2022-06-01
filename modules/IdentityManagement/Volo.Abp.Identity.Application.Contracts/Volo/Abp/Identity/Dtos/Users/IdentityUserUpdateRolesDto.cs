using System.ComponentModel.DataAnnotations;

namespace Volo.Abp.Identity.Dtos.Users;

public class IdentityUserUpdateRolesDto
{
    /// <summary>
    /// 角色集合
    /// </summary>
    [Required]
    public string[] RoleNames { get; set; }
}