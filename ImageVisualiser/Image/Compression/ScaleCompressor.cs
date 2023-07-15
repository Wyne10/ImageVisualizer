using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public class ScaleCompressor : Compressor
    {
        public override Bitmap Compress(Bitmap image, int ratio)
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
