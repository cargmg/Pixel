using System.IO;

namespace Pixel.Api.Configurations.Image
{
    public class ImageLoader : IImageLoader
    {
        private readonly byte[] imageFileBytes;

        public ImageLoader(byte[] imageFileBytes)
        { 
            this.imageFileBytes = imageFileBytes;
        }

        public Stream GetImageStream()
        {
            return new MemoryStream(imageFileBytes);
        }
    }
}
