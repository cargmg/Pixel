using System.Diagnostics.CodeAnalysis;

namespace Storage.CrossCutting.Configuration
{
    [ExcludeFromCodeCoverage]
    public class ApplicationSettings : IApplicationSettings
    {
        public string LogTrackingFilePath { get; set; }

        public MassTransit MassTransit { get; set; }
    }
}
