namespace Mars.EntityFrameworkCore;

[DependsOn(
    typeof(MarsDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule) 
    )]
public class MarsEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MarsDbContext>(options =>
        {
            // default repositories only for aggregate roots 
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(opts =>
            {
                // 实体查询不追踪
                opts.DbContextOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            /* The main point to change your DBMS. */
            options.UseMySQL();
        });
    }
}
