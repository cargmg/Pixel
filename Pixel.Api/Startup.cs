namespace Pixel.Api
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Pixel.Api.Configurations;
    using Pixel.Configurations.Context;
    using Pixel.Configurations.Middlewares;
    using Pixel.CrossCutting.Configuration;
    using Pixel.Api.Configurations.Messaging;
    using Pixel.Api.Configurations.Image;

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
                .UseCustomMiddlewares()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = ApplicationSettingsBuilder.Initialize().Get<ApplicationSettings>();

            ImageLoaderConfigurator.Initialize(services);

            services
                .AddSingleton<IApplicationSettings>(appSettings)
                .AddApplicationContext()
                .AddDependencies(appSettings)
                .AddMassTransitConfiguration(appSettings)
                .AddControllers();
        }
    }
}