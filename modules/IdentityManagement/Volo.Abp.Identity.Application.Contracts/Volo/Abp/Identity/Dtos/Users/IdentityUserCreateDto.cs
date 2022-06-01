using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Validation;

namespace Volo.Abp.Identity.Dtos.Users;

public class IdentityUserCreateDto : IdentityUserCreateOrUpdateDtoBase
{
    /// <summary>
    /// ����
    /// </summary>
    [DisableAuditing]
    [Required]
    [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
    public string Password { get; set; }
}