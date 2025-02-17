using DocQnA.Application.Services.Interfaces;
using DocQnA.Presentation.UI.Navigation;
using Serilog;

namespace DocQnA.Presentation.UI.Screens;

public class MainMenuScreen : BaseScreen
{
    private readonly IScreenNavigator _navigator;
    private readonly ILogger _logger;

    private const string ASK_A_QUESTION_OPTION = "1";
    private const string EXIT_OPTION = "2";

    private const ScreenType NAVIGATE_TO_QNA_SCREEN = ScreenType.QnA;

    public MainMenuScreen(IScreenNavigator navigator, ILogger logger,
        IConsoleService consoleService) : base(consoleService)
    {
        _navigator = navigator;
        _logger = logger;
    }

    public override async Task ShowAsync(string? errorMessage = null)
    {
        while (true)
        {
            _consoleService.PrintMessage("Welcome to the QnA System!");
            _consoleService.PrintMessage("1. Ask a question");
            _consoleService.PrintMessage("2. Exit");

            var choice = _consoleService.ReadInput("Please choose an option:");

            switch (choice)
            {
                case ASK_A_QUESTION_OPTION:
                    _logger.Information("Navigating to QnA screen.");
                    await _navigator.NavigateToAsync(NAVIGATE_TO_QNA_SCREEN);
                    continue;
                case EXIT_OPTION:
                    _logger.Information("Exiting application.");
                    _consoleService.PrintMessage("Exiting the application...");
                    Environment.Exit(0);
                    break;
                default:
                    _logger.Warning("Invalid choice: {Choice}", choice);
                    _consoleService.PrintError("Invalid choice. Please try again.");
                    continue;
            }
        }
    }
}
