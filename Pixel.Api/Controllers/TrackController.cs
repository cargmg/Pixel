using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pixel.Application.Dto.Track;
using Pixel.Application.Services.Track;
using Pixel.CrossCutting.Context;
using Pixel.CrossCutting.Exceptions;
using Pixel.Api.Configurations.Image;

namespace Pixel.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class TrackController : ControllerBase
    {
        private readonly IApplicationContext applicationContext;
        private readonly IImageLoader imageLoader;
        private readonly ITrackService trackService;

        public TrackController(IApplicationContext applicationContext, IImageLoader imageLoader, ITrackService trackService)
        {
            this.applicationContext = applicationContext;
            this.imageLoader = imageLoader;
            this.trackService = trackService;
        }

        [HttpGet("/track")]
        public async Task<IActionResult> GetTrackAsync()
        {
            var visitorIp = this.applicationContext.GetVisitorIp();
            if (string.IsNullOrEmpty(visitorIp))
            {
                throw new InvalidRequestArgumentException("VisitorIp cannot be null.");
            }

            var referer = this.applicationContext.GetReferer();
            var userAgent = this.applicationContext.GetUserAgent();

            var trackRequest = new TrackRequest
            {
                OccurenceTimeUTC = DateTime.UtcNow,
                Referer = referer,
                UserAgent  = userAgent,
                VisitorIp = visitorIp
            };

            await this.trackService.AddTrackAsync(trackRequest);

            return File(imageLoader.GetImageStream(), "image/gif");
        }
    }
}