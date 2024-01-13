namespace Pixel.Api.Configurations
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.DependencyInjection;
    using Pixel.Application.Messaging;
    using Pixel.Application.Services.Mappers;
    using Pixel.Application.Services.Track;
    using Pixel.CrossCutting.Configuration;

    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(
            this IServiceCollection services,
            IApplicationSettings appSettings)
        {
            return services
                .AddApplicationMessagingDependencies()
                .AddApplicationServicesDependencies();
        }

        private static IServiceCollection AddApplicationServicesDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<ITrackMapper, TrackMapper>()
                .AddScoped<ITrackService, TrackService>();
        }

        private static IServiceCollection AddApplicationMessagingDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IMessagingService, MessagingService>();
        }
    }
}