using System.Threading.Tasks;
using Pixel.Application.Dto.Track;

namespace Pixel.Application.Services.Track
{
    public interface ITrackService
    {
        Task AddTrackAsync(TrackRequest trackRequest);
    }
}
