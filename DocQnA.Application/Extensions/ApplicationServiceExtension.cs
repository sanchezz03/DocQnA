using DocQnA.Application.Services;
using DocQnA.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DocQnA.Application.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            //Singleton Services
            .AddSingleton<IConsoleService, ConsoleService>()

            //Scoped Services
            .AddScoped<IQnAService, QnAService>();
    }
}
