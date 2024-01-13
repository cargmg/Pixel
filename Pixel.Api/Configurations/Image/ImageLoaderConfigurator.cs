namespace Pixel.Api.Configurations.Image
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Microsoft.Extensions.DependencyInjection;

    [ExcludeFromCodeCoverage]
    internal static class ImageLoaderConfigurator
    {
        private const string ImageName = "pixel.gif";

        internal static void Initialize(this IServiceCollection services)
        {
            var imagePath = Path.Combine(Environment.CurrentDirectory, ImageName);
            var imageFileBytes = File.ReadAllBytes(imagePath);

            services.AddSingleton<IImageLoader>(new ImageLoader(imageFileBytes));
        }
    }
}
