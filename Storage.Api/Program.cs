namespace Storage.Presentation.Api
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (!int.TryParse(Environment.GetEnvironmentVariable("SERVICE_PORT"), out int port))
            {
                port = 9888;
            }

            CreateHostBuilder(args, port).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, int port) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.ListenAnyIP(port);
                    })
                    .UseStartup<Startup>();
                });
    }
}