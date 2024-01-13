using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using Pixel.Api.Configurations.Context;
using Xunit;

namespace Pixel.Unit.Tests.Api.Configurations.Context
{
    public class ApplicationContextTests
    {
        private readonly Mock<IHttpContextAccessor> request;
        private readonly Mock<HttpContext> context;
        private readonly ApplicationContext applicationContext;

        public ApplicationContextTests()
        {
            this.request = new Mock<IHttpContextAccessor>();
            this.context = new Mock<HttpContext>();

            this.request.Setup(x => x.HttpContext).Returns(this.context.Object);

            this.applicationContext = new ApplicationContext(this.request.Object);
        }

        [Fact]
        public void GetReferer_Ok()
        {
            // Arrange
            var referer = "referer";

            var headers = new Dictionary<string, StringValues>
            {
                { HeaderConstants.Referer, referer }
            };

            this.SetupHeaders(headers);

            // Act
            var result = this.applicationContext.GetReferer();

            // Assert
            Assert.Equal(referer, result);
        }

        [Fact]
        public void GetUserAgent_Ok()
        {
            // Arrange
            var userAgent = "userAgent";

            var headers = new Dictionary<string, StringValues>
            {
                { HeaderConstants.UserAgent, userAgent }
            };

            this.SetupHeaders(headers);

            // Act
            var result = this.applicationContext.GetUserAgent();

            // Assert
            Assert.Equal(userAgent, result);
        }

        [Fact]
        public void GetVisitorIp_Ok()
        {
            // Arrange
            var ipAddress = new IPAddress(1);
            var connectionInfo = new Mock<ConnectionInfo>();

            connectionInfo.Setup(x => x.RemoteIpAddress)
                .Returns(ipAddress);

            this.context.Setup(x => x.Connection)
                .Returns(connectionInfo.Object);

            // Act
            var result = this.applicationContext.GetVisitorIp();

            // Assert
            Assert.Equal("1.0.0.0", result);
        }

        private void SetupHeaders(Dictionary<string, StringValues> keyValuePairs)
        {
            var headers = new HeaderDictionary(keyValuePairs) as IHeaderDictionary;

            var httpRequest = new Mock<HttpRequest>();
            httpRequest.Setup(x => x.Headers).Returns(headers);

            this.context.Setup(x => x.Request).Returns(httpRequest.Object);
        }
    }
}
