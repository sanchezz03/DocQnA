using DocQnA.Presentation.Hosting;
using DocQnA.Presentation.UI.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DocQnA.Presentation;

class Program
{
    static async Task Main()
    {
        try
        {
            var host = ApplicationHostBuilder.CreateHostBuilder().Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Application started successfully.");

            var navigator = host.Services.GetRequiredService<IScreenNavigator>();
            await navigator.NavigateToAsync(ScreenType.MainMenu);
        }
        catch (Exception ex)
        {
            var logger = LoggerFactory.Create(builder => builder.AddSerilog()).CreateLogger<Program>();
            logger.LogError(ex, "An error occurred while navigating.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
