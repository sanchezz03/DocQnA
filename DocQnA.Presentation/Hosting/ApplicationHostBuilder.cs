using DocQnA.Application.Extensions;
using DocQnA.Infrastructure.ConfigurationModels;
using DocQnA.Infrastructure.ConfigurationOptions;
using DocQnA.Infrastructure.Extensions;
using DocQnA.Presentation.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DocQnA.Presentation.Hosting;

public static class ApplicationHostBuilder
{
    public static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .AddLogger()
            .AddConfiguration()
            .ConfigureServices((hostContext, services) =>
            {
                services.Configure<AzureOpenAIConfiguration>(hostContext.Configuration);
                services.AddScoped<IConfigureOptions<AzureOpenAIConfiguration>, AzureOpenAIConfigurationOptions>();
                //services.Configure<AzureOpenAIConfiguration>(hostContext.Configuration.GetSection("AzureOpenAIConfiguration"));

                services
                    .AddInfrastructureServices()
                    .AddApplicationServices()
                    .AddPresentationServices();
            });
    }
}
