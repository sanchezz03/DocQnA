namespace DocQnA.Infrastructure.ConfigurationModels;

public class AzureOpenAIConfiguration
{
    public string ApiKey { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
}
