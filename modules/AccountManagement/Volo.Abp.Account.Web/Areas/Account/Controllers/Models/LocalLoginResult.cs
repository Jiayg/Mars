namespace Volo.Abp.Account.Web.Areas.Account.Controllers.Models;

public class LocalLoginResult
{
    public string AccessToken { set; get; }
    public long ExpiresIn { set; get; }
    public string TokenType { set; get; }
    public string RefreshToken { set; get; }
    public string Scope { set; get; }
}