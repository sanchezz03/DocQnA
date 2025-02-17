using DocQnA.Infrastructure.Azure.Services;
using DocQnA.Infrastructure.Azure.Services.Interfaces;
using DocQnA.Infrastructure.Storage.Services;
using DocQnA.Infrastructure.Storage.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DocQnA.Infrastructure.Extensions;

public static class InfrastructureServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IAzureOpenAIService, AzureOpenAIService>()
            .AddScoped<IFileStorageService, FileStorageService>();
    }
}
