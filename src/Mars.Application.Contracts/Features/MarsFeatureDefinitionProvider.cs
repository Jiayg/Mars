using Volo.Abp.Features;
using Volo.Abp.Validation.StringValues;

namespace Mars.Application.Contracts.Features;

public class MarsFeatureDefinitionProvider : FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {
        var group = context.AddGroup(MarsFeatures.GroupName);
        group.AddFeature(MarsFeatures.SocialLogins, "true", L("Feature:SocialLogins"), valueType: new ToggleStringValueType());
        group.AddFeature(MarsFeatures.UserCount, "10", L("Feature:UserCount"), valueType: new FreeTextStringValueType(new NumericValueValidator(1, 1000)));
        group.AddFeature(MarsFeatures.PdfReporting, defaultValue: "false");
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MarsResource>(name);
    }
}