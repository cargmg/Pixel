namespace Pixel.Api.Configurations
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.Configuration;

    [ExcludeFromCodeCoverage]
    internal static class ApplicationSettingsBuilder
    {
        internal static IConfiguration Initialize()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
