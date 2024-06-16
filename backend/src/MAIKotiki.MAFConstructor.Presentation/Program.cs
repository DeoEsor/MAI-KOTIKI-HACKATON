using Dapper;

using Glasno.Common.Core;
using Glasno.Common.Logging;

namespace MAIKotiki.MAFConstructor.Presentation;

public static class Program
{
    public static async Task Main(string[] args)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        const string serviceName = "creeper.creeper";
        IHost app = await GlasnoCoreInjection.CreateApp(args, serviceName, CreateHostBuilder);

        await app.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureLogging()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}