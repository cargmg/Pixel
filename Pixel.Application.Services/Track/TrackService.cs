using System.Threading.Tasks;
using GuardNet;
using Pixel.Application.Dto.Track;
using Pixel.Application.Messaging;
using Pixel.Application.Services.Mappers;

namespace Pixel.Application.Services.Track
{
    public class TrackService : ITrackService
    {
        private readonly IMessagingService messagingService;
        private readonly ITrackMapper trackMapper;

        public TrackService(IMessagingService messagingService, ITrackMapper trackMapper)
        {
            this.messagingService = messagingService;
            this.trackMapper = trackMapper;
        }

        public async Task AddTrackAsync(TrackRequest trackRequest)
        {
            Guard.NotNull(trackRequest, nameof(trackRequest));

            await this.messagingService.PublishMessageAsync(this.trackMapper.ToEvent(trackRequest));
        }
    }
}
