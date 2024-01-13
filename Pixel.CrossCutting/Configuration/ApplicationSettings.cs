using System.Diagnostics.CodeAnalysis;

namespace Pixel.CrossCutting.Configuration
{
    [ExcludeFromCodeCoverage]
    public class ApplicationSettings : IApplicationSettings
    {
        public MassTransit MassTransit { get; set; }
    }
}
