namespace Mars.HttpApi.Host;

[DependsOn(
    typeof(MarsHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(MarsApplicationModule),
    typeof(MarsEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class MarsHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureAuthentication(context, configuration);
        ConfigureLocalization();
        ConfigureCache();
        ConfigureVirtualFileSystem(context);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
    }

    /// <summary>
    /// 缓存前缀
    /// </summary>
    private void ConfigureCache()
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "Mars:"; });
    }

    /// <summary>
    /// 虚拟文件
    /// </summary>
    /// <param name="context"></param>
    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<MarsDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Mars.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<MarsDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Mars.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<MarsApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Mars.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<MarsApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Mars.Application"));
            });
        }
    }

    /// <summary>
    /// 动态api 废弃
    /// </summary>
    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(MarsApplicationModule).Assembly);
        });
    }

    /// <summary>
    /// 身份认证
    /// </summary>
    /// <param name="context"></param>
    /// <param name="configuration"></param>
    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = "Mars";
            });
    }

    /// <summary>
    /// 接口文档
    /// </summary>
    /// <param name="context"></param>
    /// <param name="configuration"></param>
    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"],
            new Dictionary<string, string>
            {
                    {"Mars", "Mars API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mars API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Mars.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Mars.Application.Contracts.xml"));

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.Account.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.Account.Application.Contracts.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.FeatureManagement.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.FeatureManagement.Application.Contracts.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.Identity.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.Identity.Application.Contracts.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.PermissionManagement.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.PermissionManagement.Application.Contracts.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.SettingManagement.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.SettingManagement.Application.Contracts.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.TenantManagement.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Volo.Abp.TenantManagement.Application.Contracts.xml"));
            });
    }

    /// <summary>
    /// 多语言
    /// </summary>
    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        });
    }

    /// <summary>
    /// 跨越
    /// </summary>
    /// <param name="context"></param>
    /// <param name="configuration"></param>
    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mars API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            options.OAuthScopes("Mars");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}