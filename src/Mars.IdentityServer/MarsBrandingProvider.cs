namespace Mars.IdentityServer;

[Dependency(ReplaceServices = true)]
public class MarsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Mars";
}