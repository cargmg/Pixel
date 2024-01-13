using System.Threading.Tasks;

namespace Pixel.Application.Messaging
{
    public interface IMessagingService
    {
        public Task PublishMessageAsync<T>(T message) where T : class;
    }
}
