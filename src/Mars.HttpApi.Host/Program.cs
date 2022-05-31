namespace Mars.HttpApi.Host;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
#if DEBUG
            .WriteTo.Async(c => c.Console())
#endif
            .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);
        builder.Host.ConfigureAppConfiguration((context, config) =>
        {
            var env = context.HostingEnvironment;
            //context.Configuration = config.Build();
            //config.AddConsul(item,
            //                options =>
            //                {
            //                    options.Optional = true;
            //                    options.ReloadOnChange = true;
            //                    options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
            //                    options.ConsulConfigurationOptions = cco => { cco.Address = new Uri(consul_url); };
            //                }).AddEnvironmentVariables();
        })
        .UseAutofac()
        .UseSerilog();

        await builder.AddApplicationAsync<MarsHttpApiHostModule>();
        var app = builder.Build();
        await app.InitializeApplicationAsync();
        await app.RunAsync();
    }
}