using System;

namespace Storage.Application.Dto.Track
{
    public class TrackStorageRequest
    {
        public DateTime OccurenceTimeUTC { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }

        public string VisitorIp { get; set; }
    }
}
