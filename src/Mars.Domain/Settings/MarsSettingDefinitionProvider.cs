using Volo.Abp.Settings;

namespace Mars.Domain.Settings;

public class MarsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MarsSettings.MySetting1));
    }
}
