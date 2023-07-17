using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public class ScaleCompressor : ICompressor
    {
        public Bitmap Compress(Bitmap image, int ratio)
        {
            Bitmap compressedImage;

            ICompressor widthCompressor = new WidthCompressor();
            ICompressor heightCompressor = new HeightCompressor();

            compressedImage = widthCompressor.Compress(image, ratio);
            compressedImage = heightCompressor.Compress(compressedImage, ratio);

            return compressedImage;
        }
    }
}
