using DocQnA.Application.Services.Interfaces;

namespace DocQnA.Presentation.UI.Screens;

public abstract class BaseScreen
{
    protected readonly IConsoleService _consoleService;

    protected BaseScreen(IConsoleService consoleService)
    {
        _consoleService = consoleService;
    }

    public abstract Task ShowAsync(string? errorMessage = null);
}
