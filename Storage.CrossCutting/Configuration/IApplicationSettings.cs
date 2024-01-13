namespace Storage.CrossCutting.Configuration
{
    public interface IApplicationSettings
    {
        public string LogTrackingFilePath { get; set; }

        public MassTransit MassTransit { get; set; }
    }
}
