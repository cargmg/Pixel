using MassTransit;
using Moq;
using Pixel.Events.Track;
using Storage.Application.Dto.Track;
using Storage.Application.Messaging.Consumers;
using Storage.Application.Messaging.Mappers;
using Storage.Application.Services.Storage;
using Xunit;

namespace Storage.Unit.Tests.Application.Messaging.Consumers
{
    public class TrackAddedConsumerTests
    {
        private Mock<IStorageService> storageServiceMock;
        private Mock<ITrackMapper> trackMapperMock;
        private readonly TrackAddedConsumer trackAddedConsumer;

        public TrackAddedConsumerTests()
        {
            this.storageServiceMock = new Mock<IStorageService>();
            this.trackMapperMock = new Mock<ITrackMapper>();

            this.storageServiceMock.Setup(x => x.StoreTrackAsync(It.IsAny<TrackStorageRequest>()))
                .Returns(Task.CompletedTask);

            this.trackMapperMock.Setup(x => x.ToDto(It.IsAny<TrackAdded>()))
                .Returns(new TrackStorageRequest());

            this.trackAddedConsumer = new TrackAddedConsumer(
                this.storageServiceMock.Object,
                this.trackMapperMock.Object);
        }

        [Fact]
        public async Task Consume_Ok()
        {
            // Arrange
            var trackAddedMessage = new Mock<ConsumeContext<TrackAdded>>();
            trackAddedMessage.Setup(x => x.Message)
                .Returns(new TrackAdded());

            // Act
            await this.trackAddedConsumer.Consume(trackAddedMessage.Object);

            // Assert
            this.storageServiceMock.Verify(x => x.StoreTrackAsync(It.IsAny<TrackStorageRequest>()), Times.Once);
            this.trackMapperMock.Verify(x => x.ToDto(It.IsAny<TrackAdded>()), Times.Once);
        }
    }
}
