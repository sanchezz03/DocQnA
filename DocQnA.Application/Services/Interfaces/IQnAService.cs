namespace DocQnA.Application.Services.Interfaces;

public interface IQnAService
{
    Task<string> ProcessDocumentsAndAnswerQuestionAsync(string folderPath, string question);
}