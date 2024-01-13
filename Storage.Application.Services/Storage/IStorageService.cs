using System.Threading.Tasks;
using Storage.Application.Dto.Track;

namespace Storage.Application.Services.Storage
{
    public interface IStorageService
    {
        Task StoreTrackAsync(TrackStorageRequest trackStorageRequest);
    }
}
