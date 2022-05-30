namespace Mars.HttpApi;

[DependsOn(
    typeof(MarsApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule), 
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class MarsHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MarsResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
