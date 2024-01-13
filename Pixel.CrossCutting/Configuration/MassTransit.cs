using System.Diagnostics.CodeAnalysis;

namespace Pixel.CrossCutting.Configuration
{
    [ExcludeFromCodeCoverage]
    public class MassTransit
    {
        public string Url { get; set; }

        public string Host { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
