using Azure.AI.OpenAI;
using DocQnA.Infrastructure.Azure.Services.Interfaces;
using DocQnA.Infrastructure.ConfigurationModels;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using System.ClientModel;

namespace DocQnA.Infrastructure.Azure.Services;

public class AzureOpenAIService : IAzureOpenAIService
{
    private readonly AzureOpenAIClient _azureClient;

    private const string COMPLETION_DEPLOYMENT_NAME = "gpt-4";
    private const string EMBEDDING_DEPLOYMENT_NAME = "text-embedding-3-large";

    public AzureOpenAIService(IOptions<AzureOpenAIConfiguration> options)
    {
        var config = options.Value;
        _azureClient = new AzureOpenAIClient(new Uri(config.Endpoint), new ApiKeyCredential(config.ApiKey));
    }

    public async Task<string> GetCompletionAsync(string prompt)
    {
        ChatClient chatClient = _azureClient.GetChatClient(COMPLETION_DEPLOYMENT_NAME);

        ChatCompletion completion = await chatClient.CompleteChatAsync(
            [
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage(prompt),
            ]);

        return completion.Content[0].Text;
    }

    public async Task<float[]> GetEmbeddingAsync(string text)
    {
        var embeddingClient = _azureClient.GetEmbeddingClient(deploymentName: EMBEDDING_DEPLOYMENT_NAME);

        var result = await embeddingClient.GenerateEmbeddingsAsync(new[] { text });

        return result?.Value?.FirstOrDefault().ToFloats().ToArray() 
            ?? throw new Exception("Error getting embedding.");
    }
}
