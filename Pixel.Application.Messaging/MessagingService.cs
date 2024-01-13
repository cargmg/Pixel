using System.Threading.Tasks;
using MassTransit;

namespace Pixel.Application.Messaging
{
    public class MessagingService : IMessagingService
    {
        private readonly IPublishEndpoint publishEndpoint;

        public MessagingService(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task PublishMessageAsync<T>(T message) where T : class
        {
            await this.publishEndpoint.Publish(message);
        }
    }
}
