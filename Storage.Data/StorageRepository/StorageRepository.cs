using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Storage.CrossCutting.Configuration;

namespace Storage.Data.Repositories.StorageRepository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
        private readonly string logTrackingFilePath;

        public StorageRepository(IApplicationSettings applicationSettings)
        {
            this.logTrackingFilePath = applicationSettings.LogTrackingFilePath;
        }

        public async Task SaveTrackAsync(DateTime occurenceTimeUTC, string referer, string userAgent, string visitorIp)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                using (StreamWriter outputFile = new StreamWriter(logTrackingFilePath, true))
                {
                    await outputFile.WriteLineAsync($"{occurenceTimeUTC}|{referer}|{userAgent}|{visitorIp}");
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
