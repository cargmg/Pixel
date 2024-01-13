using System;
using System.Threading.Tasks;

namespace Storage.Data.Repositories.StorageRepository
{
    public interface IStorageRepository
    {
        Task SaveTrackAsync(DateTime occurenceTimeUTC, string referer, string userAgent, string visitorIp);
    }
}
