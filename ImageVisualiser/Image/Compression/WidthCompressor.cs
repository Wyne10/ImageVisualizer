using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public class WidthCompressor : ChunkCompressor
    {
        public override Bitmap Compress(Bitmap image, int ratio)
        {
            if (ratio == 1)
                return image;

            var compressedImage = new Bitmap(image.Width / ratio, image.Height);

            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x += ratio)
                {
                    if (x / ratio >= image.Width / ratio)
                        break;

                    var pixelChunk = GetPixelChunk(x, ratio, (int currentPixel) => { return image.GetPixel(currentPixel, y); });
                    compressedImage.SetPixel(x / ratio, y, CompressPixelChunk(pixelChunk, ratio));
                }
            }

            return compressedImage;
        }
    }
}
