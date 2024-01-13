using System;

namespace Pixel.Application.Dto.Track
{
    public class TrackRequest
    {
        public DateTime OccurenceTimeUTC { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }

        public string VisitorIp { get; set; }
    }
}
