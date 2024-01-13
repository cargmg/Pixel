namespace Storage.Presentation.Api
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Storage.Api.Configurations;
    using Storage.CrossCutting.Configuration;
    using Storage.Presentation.Api.Configurations.Messaging;

    [ExcludeFromCodeCoverage]
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void Configure(IApplicationBuilder app)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = ApplicationSettingsBuilder.Initialize().Get<ApplicationSettings>();

            SetupStorageFileDirectory(appSettings);

            services
                .AddSingleton<IApplicationSettings>(appSettings)
                .AddDependencies(appSettings)
                .AddMassTransitConfiguration(appSettings)
                .AddControllers();
        }

        private static void SetupStorageFileDirectory(IApplicationSettings applicationSettings)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, applicationSettings.LogTrackingFilePath);
            applicationSettings.LogTrackingFilePath = filePath;

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
    }
}