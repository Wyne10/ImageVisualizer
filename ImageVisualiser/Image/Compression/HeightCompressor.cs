using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public class HeightCompressor : ChunkCompressor
    {
        public override Bitmap Compress(Bitmap image, int ratio)
        {
            if (ratio == 1)
                return image;

            var compressedImage = new Bitmap(image.Width, image.Height / ratio);

            for (var x = 0; x < image.Width; x++)
            {
                for (var y = 0; y < image.Height; y += ratio)
                {
                    if (y / ratio >= image.Height / ratio)
                        break;

                    var pixelChunk = GetPixelChunk(image, y, ratio, (int currentPixel) => { return image.GetPixel(x, currentPixel); });
                    compressedImage.SetPixel(x, y / ratio, CompressPixelChunk(pixelChunk, ratio));
                }
            }

            return compressedImage;
        }
    }
}
