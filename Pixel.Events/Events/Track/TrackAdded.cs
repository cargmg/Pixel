using System;

namespace Pixel.Events.Track
{
    public class TrackAdded
    {
        public DateTime OccurenceTimeUTC { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }

        public string VisitorIp { get; set; }
    }
}
