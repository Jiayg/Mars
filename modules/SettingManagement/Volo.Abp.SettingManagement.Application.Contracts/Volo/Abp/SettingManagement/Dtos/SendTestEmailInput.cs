using System.ComponentModel.DataAnnotations;

namespace Volo.Abp.SettingManagement.Dtos;

public class SendTestEmailInput
{
    /// <summary>
    /// 发件人邮件地址
    /// </summary>
    [Required]
    public string SenderEmailAddress { get; set; }

    /// <summary>
    /// 目标邮件地址
    /// </summary>
    [Required]
    public string TargetEmailAddress { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [Required]
    public string Subject { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Body { get; set; }
}