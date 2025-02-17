using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DocQnA.Presentation.Extensions;

public static class LoggerExtension
{
    public static IHostBuilder AddLogger(this IHostBuilder hostBuilder)
    {
        Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

        return hostBuilder
            .UseSerilog()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton(Log.Logger);
            });
    }
}
