using System.ComponentModel.DataAnnotations;

namespace Volo.Abp.Account.Web.Areas.Account.Controllers.Models;

public class LocalLoginInfo
{
    /// <summary>
    /// 登录地址
    /// </summary>
    public string LoginUrl { set; get; }

    /// <summary>
    /// id
    /// </summary>
    public string Client_id { set; get; }

    /// <summary>
    /// 秘钥
    /// </summary>
    public string Client_secret { set; get; }

    /// <summary>
    /// 授权类型
    /// </summary>
    public string Grant_type { set; get; }

    /// <summary>
    /// 范围
    /// </summary>
    public string Scope { set; get; }

    /// <summary>
    /// 用户名
    /// </summary>
    [Required]
    public string Username { set; get; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required]
    public string Password { set; get; }
}