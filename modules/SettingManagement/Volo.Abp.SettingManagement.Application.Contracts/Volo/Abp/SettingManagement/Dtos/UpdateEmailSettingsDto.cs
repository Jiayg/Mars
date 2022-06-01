using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Volo.Abp.SettingManagement.Dtos;

public class UpdateEmailSettingsDto
{
    /// <summary>
    /// 邮箱地址
    /// </summary>
    [MaxLength(256)]
    public string SmtpHost { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    [Range(1, 65535)]
    public int SmtpPort { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(1024)]
    public string SmtpUserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [MaxLength(1024)]
    [DataType(DataType.Password)]
    [DisableAuditing]
    public string SmtpPassword { get; set; }

    /// <summary>
    /// 领域
    /// </summary>
    [MaxLength(1024)]
    public string SmtpDomain { get; set; }

    /// <summary>
    /// 是否开启ssl
    /// </summary>
    public bool SmtpEnableSsl { get; set; }

    /// <summary>
    /// 是否使用默认凭据
    /// </summary>
    public bool SmtpUseDefaultCredentials { get; set; }

    /// <summary>
    /// 默认发送邮件地址
    /// </summary>
    [MaxLength(1024)]
    [Required]
    public string DefaultFromAddress { get; set; }

    /// <summary>
    /// 默认发送用户名
    /// </summary>
    [MaxLength(1024)]
    [Required]
    public string DefaultFromDisplayName { get; set; }
}