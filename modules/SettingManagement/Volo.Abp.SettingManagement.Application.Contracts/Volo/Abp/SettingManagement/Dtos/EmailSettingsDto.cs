namespace Volo.Abp.SettingManagement.Dtos;

public class EmailSettingsDto
{
    /// <summary>
    /// 邮箱地址
    /// </summary>
    public string SmtpHost { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    public int SmtpPort { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string SmtpUserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string SmtpPassword { get; set; }

    /// <summary>
    /// 领域
    /// </summary>
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
    public string DefaultFromAddress { get; set; }

    /// <summary>
    /// 默认发送用户名
    /// </summary>
    public string DefaultFromDisplayName { get; set; }
}