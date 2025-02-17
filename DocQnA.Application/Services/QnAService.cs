using DocQnA.Application.Services.Interfaces;
using DocQnA.Infrastructure.Azure.Services.Interfaces;
using DocQnA.Infrastructure.Helpers;
using DocQnA.Infrastructure.Models;
using DocQnA.Infrastructure.Storage.Services.Interfaces;

namespace DocQnA.Application.Services;

public class QnAService : IQnAService
{
    private readonly IFileStorageService _fileStorageService;
    private readonly IAzureOpenAIService _azureOpenAIService;
    private readonly List<DocumentEmbedding> _documentEmbeddings;

    public QnAService(IFileStorageService fileStorageService, IAzureOpenAIService azureOpenAIService)
    {
        _fileStorageService = fileStorageService;
        _azureOpenAIService = azureOpenAIService;
        _documentEmbeddings = new List<DocumentEmbedding>();
    }

    public async Task<string> ProcessDocumentsAndAnswerQuestionAsync(string folderPath, string question)
    {
        await LoadDocumentsAndComputeEmbeddingsAsync(folderPath);

        return await HandleQuestionAsync(question);
    }

    #region Private methods

    private async Task LoadDocumentsAndComputeEmbeddingsAsync(string folderPath)
    {
        var documentPaths = _fileStorageService.GetDocumentPaths(folderPath);
        foreach (var documentPath in documentPaths)
        {
            var content = await _fileStorageService.ReadDocumentAsync(documentPath);
            var embedding = await _azureOpenAIService.GetEmbeddingAsync(content);
            _documentEmbeddings.Add(new DocumentEmbedding
            {
                FilePath = documentPath,
                Embedding = embedding
            });
        }
    }

    private async Task<string> HandleQuestionAsync(string question)
    {
        var questionEmbedding = await _azureOpenAIService.GetEmbeddingAsync(question);

        var topDocuments = GetTopMatchingDocuments(questionEmbedding);

        var prompt = BuildPrompt(question, topDocuments);

        return await _azureOpenAIService.GetCompletionAsync(prompt);
    }

    private List<DocumentEmbedding> GetTopMatchingDocuments(float[] questionEmbedding)
    {
        return _documentEmbeddings
            .Select(doc => new
            {
                Document = doc,
                Similarity = CosineSimilarityHelper.CalculateCosineSimilarity(questionEmbedding, doc.Embedding)
            })
            .OrderByDescending(x => x.Similarity)
            .Take(3) 
            .Select(x => x.Document)
            .ToList();
    }

    private string BuildPrompt(string question, List<DocumentEmbedding> topDocuments)
    {
        var context = string.Join("\n", topDocuments.Select(doc => File.ReadAllText(doc.FilePath)));
        return $"{context}\n\nQuestion: {question}\nAnswer:";
    }

    #endregion
}