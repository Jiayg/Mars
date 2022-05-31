using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Mars.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MarsEntityFrameworkCoreModule),
    typeof(MarsApplicationContractsModule)
    )]
public class MarsDbMigratorModule : AbpModule
{
    //// 表前缀
    //public override void PreConfigureServices(ServiceConfigurationContext context)
    //{
    //    AbpCommonDbProperties.DbTablePrefix = "mars_";
    //    AbpPermissionManagementDbProperties.DbTablePrefix = "mars_";
    //    AbpSettingManagementDbProperties.DbTablePrefix = "mars_";
    //    AbpIdentityDbProperties.DbTablePrefix = "mars_";
    //    AbpIdentityServerDbProperties.DbTablePrefix = "ids4_";
    //}

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}