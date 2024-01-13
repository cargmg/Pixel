namespace Pixel.CrossCutting.Context
{
    public interface IApplicationContext
    {
        string GetReferer();

        string GetUserAgent();

        string GetVisitorIp();
    }
}