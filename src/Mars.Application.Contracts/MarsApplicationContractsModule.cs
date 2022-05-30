namespace Mars.Application.Contracts;

[DependsOn(
    typeof(MarsDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class MarsApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    { 
    }
}
