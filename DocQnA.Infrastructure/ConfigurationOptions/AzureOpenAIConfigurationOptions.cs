using DocQnA.Infrastructure.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DocQnA.Infrastructure.ConfigurationOptions;

public class AzureOpenAIConfigurationOptions : IConfigureOptions<AzureOpenAIConfiguration>
{
    private readonly IConfiguration _configuration;

    public AzureOpenAIConfigurationOptions(IConfiguration configuration)
    {
       _configuration = configuration;
    }

    public void Configure(AzureOpenAIConfiguration options)
    {
        var azureOpenAIConfig = _configuration.GetSection("AzureOpenAIConfiguration");

        options.ApiKey = azureOpenAIConfig["ApiKey"] 
            ?? throw new Exception("AzureOpenAIConfiguration.ApiKey is not set.");

        options.Endpoint = azureOpenAIConfig["EndPoint"] 
            ?? throw new Exception("AzureOpenAIConfiguration.EndPoint is not set.");
    }
}
