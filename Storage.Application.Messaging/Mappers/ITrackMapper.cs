using Pixel.Events.Track;
using Storage.Application.Dto.Track;

namespace Storage.Application.Messaging.Mappers
{
    public interface ITrackMapper
    {
        TrackStorageRequest ToDto(TrackAdded trackAdded);
    }
}
