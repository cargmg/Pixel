using Pixel.Events.Track;
using Storage.Application.Dto.Track;

namespace Storage.Application.Messaging.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        public TrackStorageRequest ToDto(TrackAdded trackAdded)
        {
            return trackAdded != null ?
                new TrackStorageRequest
                {
                    OccurenceTimeUTC = trackAdded.OccurenceTimeUTC,
                    Referer = trackAdded.Referer,
                    UserAgent = trackAdded.UserAgent,
                    VisitorIp = trackAdded.VisitorIp
                } 
                : null;
        }
    }
}
