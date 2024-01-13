using System.Threading.Tasks;
using MassTransit;
using Pixel.Events.Track;
using Storage.Application.Messaging.Mappers;
using Storage.Application.Services.Storage;

namespace Storage.Application.Messaging.Consumers
{
    public class TrackAddedConsumer :
    IConsumer<TrackAdded>
    {
        private IStorageService storageService;
        private ITrackMapper trackMapper;

        public TrackAddedConsumer(IStorageService storageService, ITrackMapper trackMapper)
        {
            this.storageService = storageService;
            this.trackMapper = trackMapper;
        }

        public async Task Consume(ConsumeContext<TrackAdded> context)
        {
            await this.storageService.StoreTrackAsync(trackMapper.ToDto(context.Message));
        }
    }
}
