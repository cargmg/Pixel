using MassTransit;
using Moq;
using Pixel.Application.Messaging;
using Xunit;

namespace Pixel.Unit.Tests.Application.Messaging
{
    public class MessagingServiceTests
    {
        private readonly Mock<IPublishEndpoint> publishEndpointMock;
        private readonly MessagingService messagingService;

        public MessagingServiceTests()
        {
            this.publishEndpointMock = new Mock<IPublishEndpoint>();
            this.messagingService = new MessagingService(this.publishEndpointMock.Object);
        }

        [Fact]
        public async Task PublishMessageAsync_Ok()
        {
            // Arrange
            this.publishEndpointMock.Setup(m => m.Publish(It.IsAny<EventTest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            await this.messagingService.PublishMessageAsync(new EventTest());

            // Assert
            this.publishEndpointMock.Verify(
                m => m.Publish(It.IsAny<EventTest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        public class EventTest
        {
        }
    }
}
