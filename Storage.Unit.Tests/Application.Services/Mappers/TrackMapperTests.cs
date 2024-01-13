using Pixel.Events.Track;
using Storage.Application.Messaging.Mappers;
using Xunit;

namespace Storage.Unit.Tests.Application.Messaging.Mappers
{
    public class TrackMapperTests
    {
        private readonly TrackMapper trackMapper = new TrackMapper();

        [Fact]
        public void ToDto_NullTrackAdded_ReturnsNull()
        {
            // Arrange
            TrackAdded trackAdded = null;

            // Act
            var result = this.trackMapper.ToDto(trackAdded);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_Ok()
        {
            // Arrange
            TrackAdded trackAdded = new TrackAdded
            {
                OccurenceTimeUTC = DateTime.UtcNow,
                Referer = "referer",
                UserAgent = "userAgent",
                VisitorIp = "visitorIp"
            };

            // Act
            var result = this.trackMapper.ToDto(trackAdded);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(trackAdded.OccurenceTimeUTC, result.OccurenceTimeUTC);
            Assert.Equal(trackAdded.Referer, result.Referer);
            Assert.Equal(trackAdded.UserAgent, result.UserAgent);
            Assert.Equal(trackAdded.VisitorIp, result.VisitorIp);
        }
    }
}
