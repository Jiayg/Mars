using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Volo.Abp.TenantManagement.Dtos;

public class TenantCreateDto : TenantCreateOrUpdateDtoBase
{
    /// <summary>
    /// 租户管理员邮箱地址
    /// </summary>
    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public virtual string AdminEmailAddress { get; set; }

    /// <summary>
    /// 租户管理员密码
    /// </summary>
    [Required]
    [MaxLength(128)]
    [DisableAuditing]
    public virtual string AdminPassword { get; set; }
}