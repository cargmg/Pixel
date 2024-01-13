namespace Pixel.Configurations.Context
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.DependencyInjection;
    using Pixel.Api.Configurations.Context;
    using Pixel.CrossCutting.Context;

    [ExcludeFromCodeCoverage]
    internal static class ApplicationContextConfiguration
    {
        internal static IServiceCollection AddApplicationContext(this IServiceCollection services)
        {
            return services
                .AddHttpContextAccessor()
                .AddTransient<IApplicationContext, ApplicationContext>();
        }
    }
}