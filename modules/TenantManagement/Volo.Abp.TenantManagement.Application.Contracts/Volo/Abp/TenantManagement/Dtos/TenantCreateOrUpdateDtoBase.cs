using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Volo.Abp.TenantManagement.Dtos;

public abstract class TenantCreateOrUpdateDtoBase : ExtensibleObject
{
    /// <summary>
    /// 租户名称
    /// </summary>
    [Required]
    [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.MaxNameLength))]
    [Display(Name = "TenantName")]
    public string Name { get; set; }

    public TenantCreateOrUpdateDtoBase() : base(false)
    {
    }
}