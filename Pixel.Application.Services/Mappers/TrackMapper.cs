using Pixel.Application.Dto.Track;
using Pixel.Events.Track;

namespace Pixel.Application.Services.Mappers
{
    public class TrackMapper : ITrackMapper
    {
        public TrackAdded ToEvent(TrackRequest trackRequest)
        {
            return trackRequest != null ?
                new TrackAdded
                {
                    OccurenceTimeUTC = trackRequest.OccurenceTimeUTC,
                    Referer = trackRequest.Referer,
                    UserAgent = trackRequest.UserAgent,
                    VisitorIp = trackRequest.VisitorIp
                } 
                : null;
        }
    }
}
