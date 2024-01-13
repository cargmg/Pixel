using System.IO;

namespace Pixel.Api.Configurations.Image
{
    public interface IImageLoader
    {
        public Stream GetImageStream();
    }
}
