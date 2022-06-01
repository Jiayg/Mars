using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Volo.Abp.Account.Dtos;

public class ResetPasswordDto
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// 重置token
    /// </summary>
    [Required]
    public string ResetToken { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required]
    [DisableAuditing]
    public string Password { get; set; }
}