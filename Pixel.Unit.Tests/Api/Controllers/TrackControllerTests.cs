using Microsoft.AspNetCore.Mvc;
using Moq;
using Pixel.Api.Configurations.Image;
using Pixel.Api.Controllers;
using Pixel.Application.Dto.Track;
using Pixel.Application.Services.Track;
using Pixel.CrossCutting.Context;
using Pixel.CrossCutting.Exceptions;
using Xunit;

namespace Pixel.Unit.Tests.Api.Controllers
{
    public class TrackControllerTests
    {
        private const string ImageName = "pixel.gif";

        private readonly Mock<IApplicationContext> applicationContextMock;
        private readonly Mock<IImageLoader> imageLoaderMock;
        private readonly Mock<ITrackService> trackServiceMock;
        private readonly TrackController trackController; 

        public TrackControllerTests()
        {
            this.applicationContextMock = new Mock<IApplicationContext>();
            this.imageLoaderMock = new Mock<IImageLoader>();
            this.trackServiceMock = new Mock<ITrackService>();

            this.applicationContextMock.Setup(x => x.GetVisitorIp())
                .Returns("visitorIp");

            this.applicationContextMock.Setup(x => x.GetReferer())
                .Returns("referer");

            this.applicationContextMock.Setup(x => x.GetUserAgent())
                .Returns("userAgent");

            var imagePath = Path.Combine(Environment.CurrentDirectory, ImageName);
            var imageFileStream = File.OpenRead(imagePath);

            this.imageLoaderMock.Setup(x => x.GetImageStream())
                .Returns(imageFileStream);

            this.trackController = new TrackController(
                applicationContextMock.Object, 
                imageLoaderMock.Object, 
                trackServiceMock.Object);
        }

        [Fact]
        public async Task GetTrackAsync_InvalidVisitorId_ExceptionExpected()
        {
            // Arrange
            this.applicationContextMock.Setup(x => x.GetVisitorIp())
                .Returns(string.Empty);

            // Act
            var exception = await Assert.ThrowsAsync<InvalidRequestArgumentException>(
                async () => await this.trackController.GetTrackAsync());

            // Assert
            Assert.Equal("VisitorIp cannot be null.", exception.Message);
        }

        [Fact]
        public async Task GetTrackAsync_Ok()
        {
            // Arrange
            this.trackServiceMock.Setup(x => x.AddTrackAsync(It.IsAny<TrackRequest>()))
                .Returns(Task.CompletedTask);

            // Act
            var response = await this.trackController.GetTrackAsync();

            // Assert
            var fileStreamResult = response as FileStreamResult;

            Assert.NotNull(fileStreamResult);

            this.trackServiceMock.Verify(
                x => x.AddTrackAsync(It.IsAny<TrackRequest>()),
                Times.Once);
        }
    }
}
