using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Mars;

[Dependency(ReplaceServices = true)]
public class MarsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Mars";
}
