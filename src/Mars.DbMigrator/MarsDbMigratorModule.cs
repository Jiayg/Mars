using Mars.Application.Contracts;
using Mars.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Mars.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MarsEntityFrameworkCoreModule),
    typeof(MarsApplicationContractsModule)
    )]
public class MarsDbMigratorModule : AbpModule
{ 
    public override void ConfigureServices(ServiceConfigurationContext context)
    { 
    }
}
