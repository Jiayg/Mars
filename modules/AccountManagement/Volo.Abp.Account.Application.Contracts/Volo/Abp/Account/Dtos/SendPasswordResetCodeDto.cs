using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Volo.Abp.Account.Dtos;

public class SendPasswordResetCodeDto
{
    /// <summary>
    /// 邮箱
    /// </summary>
    [Required]
    [EmailAddress]
    [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
    public string Email { get; set; }

    /// <summary>
    /// 应用名称
    /// </summary>
    [Required]
    public string AppName { get; set; }

    /// <summary>
    /// 重定向地址
    /// </summary>
    public string ReturnUrl { get; set; }

    /// <summary>
    /// 重定向Hash地址
    /// </summary>
    public string ReturnUrlHash { get; set; }
}