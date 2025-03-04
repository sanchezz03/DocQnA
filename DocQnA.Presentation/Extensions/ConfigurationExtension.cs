﻿using DocQnA.Infrastructure.ConfigurationModels;
using DocQnA.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DocQnA.Presentation.Extensions;

public static class ConfigurationExtension
{
    public static IHostBuilder AddConfiguration(this IHostBuilder hostBuilder, bool useFile = true)
    {
        if (useFile)
        {
            hostBuilder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
            {
                configurationBuilder.Sources.Clear();
                var env = hostingContext.HostingEnvironment;

                configurationBuilder
                     .SetBasePath(env.ContentRootPath)
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddUserSecrets<Program>()
                     .AddEnvironmentVariables()
                     .Build();
            });
        }

        hostBuilder.ConfigureServices((hostBuilder, services) =>
        {
            var configurationOptions = TypesHelper.GetTypesFromAllAssembliesByGenericInterface(typeof(IConfigureOptions<>));
            configurationOptions.ToList().ForEach(options => services.ConfigureOptions(options));
        });

        return hostBuilder;
    }
}
