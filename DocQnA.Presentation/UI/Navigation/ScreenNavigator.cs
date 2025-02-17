using DocQnA.Presentation.UI.Screens;
using Microsoft.Extensions.DependencyInjection;
using ILogger = Serilog.ILogger;

namespace DocQnA.Presentation.UI.Navigation;

public class ScreenNavigator : IScreenNavigator
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    private const ScreenType MAIN_MENU_SCREEN = ScreenType.MainMenu;
    private const ScreenType QNA_SCREEN = ScreenType.QnA;

    public ScreenNavigator(IServiceProvider serviceProvider, ILogger logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task NavigateToAsync(ScreenType screenType)
    {
        BaseScreen screen = screenType switch
        {
            MAIN_MENU_SCREEN => _serviceProvider.GetRequiredService<MainMenuScreen>(),
            QNA_SCREEN => _serviceProvider.GetRequiredService<QnAScreen>(),
            _ => throw new ArgumentException("Invalid screen type")
        };

        _logger.Information($"Navigating to screen: {screenType}");

        await screen.ShowAsync();
    }
}
