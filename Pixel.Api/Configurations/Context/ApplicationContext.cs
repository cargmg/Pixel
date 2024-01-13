namespace Pixel.Api.Configurations.Context
{
    using Microsoft.AspNetCore.Http;
    using Pixel.CrossCutting.Context;

    public class ApplicationContext : IApplicationContext
    {
        private readonly IHttpContextAccessor request;

        public ApplicationContext(IHttpContextAccessor request)
        {
            this.request = request;
        }

        public string GetReferer()
        {
            return this.GetHeader(HeaderConstants.Referer);
        }

        public string GetUserAgent()
        {
            return this.GetHeader(HeaderConstants.UserAgent);
        }

        public string GetVisitorIp()
        {
            return request.HttpContext.Connection.RemoteIpAddress?.ToString();
        }

        private string GetHeader(string key)
        {
            return this.request?.HttpContext?.Request?.Headers[key];
        }
    }
}