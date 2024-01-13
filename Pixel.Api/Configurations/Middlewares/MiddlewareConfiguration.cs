namespace Pixel.Configurations.Middlewares
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Builder;

    [ExcludeFromCodeCoverage]
    internal static class MiddlewareConfiguration
    {
        internal static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}