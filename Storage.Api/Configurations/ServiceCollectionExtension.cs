namespace Storage.Api.Configurations
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.DependencyInjection;
    using Storage.Application.Messaging.Mappers;
    using Storage.Application.Services.Storage;
    using Storage.CrossCutting.Configuration;
    using Storage.Data.Repositories.StorageRepository;

    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(
            this IServiceCollection services,
            IApplicationSettings appSettings)
        {
            return services
                .AddDataRepositoriesDependencies()
                .AddApplicationMessagingDependencies()
                .AddApplicationServicesDependencies();
        }

        private static IServiceCollection AddApplicationServicesDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IStorageService, StorageService>();
        }

        private static IServiceCollection AddApplicationMessagingDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<ITrackMapper, TrackMapper>();
        }

        private static IServiceCollection AddDataRepositoriesDependencies(this IServiceCollection services)
        {
            return services
                .AddSingleton<IStorageRepository, StorageRepository>();
        }
    }
}