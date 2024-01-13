using Pixel.Application.Dto.Track;
using Pixel.Application.Services.Mappers;
using Xunit;

namespace Pixel.Unit.Tests.Application.Services.Mappers
{
    public class TrackMapperTests
    {
        private readonly TrackMapper trackMapper = new TrackMapper();

        [Fact]
        public void ToEvent_NullTrackRequest_ReturnsNull()
        {
            // Arrange
            TrackRequest trackRequest = null;

            // Act
            var result = this.trackMapper.ToEvent(trackRequest);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToEvent_Ok()
        {
            // Arrange
            TrackRequest trackRequest = new TrackRequest
            {
                OccurenceTimeUTC = DateTime.UtcNow,
                Referer = "referer",
                UserAgent = "userAgent",
                VisitorIp = "visitorIp"
            };

            // Act
            var result = this.trackMapper.ToEvent(trackRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(trackRequest.OccurenceTimeUTC, result.OccurenceTimeUTC);
            Assert.Equal(trackRequest.Referer, result.Referer);
            Assert.Equal(trackRequest.UserAgent, result.UserAgent);
            Assert.Equal(trackRequest.VisitorIp, result.VisitorIp);
        }
    }
}
