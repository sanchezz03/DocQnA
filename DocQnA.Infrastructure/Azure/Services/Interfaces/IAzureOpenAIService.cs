namespace DocQnA.Infrastructure.Azure.Services.Interfaces;

public interface IAzureOpenAIService
{
    Task<float[]> GetEmbeddingAsync(string text);
    Task<string> GetCompletionAsync(string prompt);
}
