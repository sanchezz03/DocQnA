using DocQnA.Presentation.UI.Navigation;
using DocQnA.Presentation.UI.Screens;
using Microsoft.Extensions.DependencyInjection;

namespace DocQnA.Presentation.Extensions;

public static class PresentationServiceExtension
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        return services
            //Singleton Services
            .AddSingleton<IScreenNavigator, ScreenNavigator>()
            
            //Transient Services
            .AddTransient<QnAScreen>()
            .AddTransient<MainMenuScreen>();
    }
}
