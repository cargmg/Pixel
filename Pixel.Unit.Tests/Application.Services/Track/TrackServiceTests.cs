using Moq;
using Pixel.Application.Dto.Track;
using Pixel.Application.Messaging;
using Pixel.Application.Services.Mappers;
using Pixel.Application.Services.Track;
using Pixel.Events.Track;
using Xunit;

namespace Pixel.Unit.Tests.Application.Services.Track
{
    public class TrackServiceTests
    {
        private readonly Mock<IMessagingService> messagingServiceMock;
        private readonly Mock<ITrackMapper> trackMapperMock;
        private readonly TrackService trackService;

        public TrackServiceTests()
        {
            this.messagingServiceMock = new Mock<IMessagingService>();
            this.trackMapperMock = new Mock<ITrackMapper>();

            this.messagingServiceMock.Setup(x => x.PublishMessageAsync(It.IsAny<TrackAdded>()))
                .Returns(Task.CompletedTask);

            this.trackMapperMock.Setup(x => x.ToEvent(It.IsAny<TrackRequest>()))
                .Returns(new TrackAdded());

            this.trackService = new TrackService(
                messagingServiceMock.Object,
                trackMapperMock.Object);
        }

        [Fact]
        public async Task AddTrackAsync_NullTrackRequest_ExceptionExpected()
        {
            // Arrange
            TrackRequest trackRequest = null;

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await this.trackService.AddTrackAsync(trackRequest));

            // Assert
        }

        [Fact]
        public async Task AddTrackAsync_Ok()
        {
            // Arrange
            var trackRequest = new TrackRequest();

            // Act
            await this.trackService.AddTrackAsync(trackRequest);

            // Assert
            this.messagingServiceMock.Verify(x => x.PublishMessageAsync(It.IsAny<TrackAdded>()), Times.Once);
        }
    }
}
