using Moq;
using Storage.Application.Dto.Track;
using Storage.Application.Services.Storage;
using Storage.Data.Repositories.StorageRepository;
using Xunit;

namespace Storage.Unit.Tests.Application.Services.Storage
{
    public class StorageServiceTests
    {
        private readonly Mock<IStorageRepository> storageRepositoryMock;
        private readonly StorageService storageService;

        public StorageServiceTests()
        {
            this.storageRepositoryMock = new Mock<IStorageRepository>();
            this.storageRepositoryMock.Setup(x => x.SaveTrackAsync(
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            this.storageService = new StorageService(this.storageRepositoryMock.Object);
        }

        [Fact]
        public async Task StoreTrackAsync_Ok()
        {
            // Arrange
            var trackStorageRequest = new TrackStorageRequest();

            // Act
            await this.storageService.StoreTrackAsync(trackStorageRequest);

            // Assert
            this.storageRepositoryMock.Verify(x => x.SaveTrackAsync(
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Once);
        }
    }
}
