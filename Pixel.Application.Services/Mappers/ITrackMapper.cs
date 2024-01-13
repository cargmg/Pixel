using Pixel.Application.Dto.Track;
using Pixel.Events.Track;

namespace Pixel.Application.Services.Mappers
{
    public interface ITrackMapper
    {
        TrackAdded ToEvent(TrackRequest trackRequest);
    }
}
