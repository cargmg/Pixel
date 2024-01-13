using System.Diagnostics.CodeAnalysis;
using GuardNet;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Storage.Application.Messaging.Consumers;
using Storage.CrossCutting.Configuration;

namespace Storage.Presentation.Api.Configurations.Messaging
{
    [ExcludeFromCodeCoverage]
    public static class MassTransitConfiguration
    {
        public static IServiceCollection AddMassTransitConfiguration(
            this IServiceCollection services,
            IApplicationSettings appSettings)
        {
            var url = appSettings.MassTransit.Url;
            var host = appSettings.MassTransit.Host;
            var userName = appSettings.MassTransit.UserName;
            var password = appSettings.MassTransit.Password;

            Guard.NotNullOrEmpty(url, nameof(url));
            Guard.NotNullOrEmpty(userName, nameof(userName));
            Guard.NotNullOrEmpty(password, nameof(password));

            services.AddMassTransit(x =>
            {
                x.AddConsumer<TrackAddedConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host($"rabbitmq://{url}/{host}", configurator =>
                    {
                        configurator.Username(userName);
                        configurator.Password(password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
