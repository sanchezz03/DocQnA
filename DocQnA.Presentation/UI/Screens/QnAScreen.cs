using DocQnA.Application.Services.Interfaces;

namespace DocQnA.Presentation.UI.Screens;

public class QnAScreen : BaseScreen
{
    private readonly IQnAService _qnaService;

    private const string ASK_QUESTION_OPTION = "1";
    private const string BACK_TO_MAIN_SCREEN_OPTION = "2";

    public QnAScreen(IQnAService qnAService, IConsoleService consoleService)
        : base(consoleService)
    {
        _qnaService = qnAService;
    }

    public override async Task ShowAsync(string? errorMessage = null)
    {
        while (true)
        {
            _consoleService.PrintMessage("Options:");
            _consoleService.PrintMessage("1 - Ask a question");
            _consoleService.PrintMessage("2 - Return to Main Menu");

            string choice = _consoleService.ReadInput("Please select an option:");

            switch (choice.Trim())
            {
                case ASK_QUESTION_OPTION:
                    await AskQuestionAsync();
                    continue;

                case BACK_TO_MAIN_SCREEN_OPTION:
                    return; 

                default:
                    _consoleService.PrintError("Invalid option. Please try again.");
                    continue;
            }
        }
    }

    #region Private methods

    private async Task AskQuestionAsync()
    {
        string question = _consoleService.ReadInput("Please enter your question.");

        if (string.IsNullOrWhiteSpace(question))
        {
            _consoleService.PrintError($"You didn't ask any question");
            return;
        }

        var answer = await _qnaService.ProcessDocumentsAndAnswerQuestionAsync("Documents", question);

        _consoleService.PrintMessage($"Answer: {answer}");
    }

    #endregion
}
