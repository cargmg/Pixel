using System.Threading.Tasks;
using Storage.Application.Dto.Track;
using Storage.Data.Repositories.StorageRepository;

namespace Storage.Application.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository storageRepository;

        public StorageService(IStorageRepository storageRepository) 
        { 
            this.storageRepository = storageRepository;
        }

        public async Task StoreTrackAsync(TrackStorageRequest trackStorageRequest)
        {
            await this.storageRepository.SaveTrackAsync(
                trackStorageRequest.OccurenceTimeUTC,
                trackStorageRequest.Referer, 
                trackStorageRequest.UserAgent, 
                trackStorageRequest.VisitorIp);
        }
    }
}
