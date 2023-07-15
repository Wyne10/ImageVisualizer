using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public class HeightCompressor : Compressor
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

                    var pixelChunk = new Color[ratio];

                    int i = 0;
                    for (var pixel = y; pixel < y + ratio; pixel++)
                    {
                        if (image.Height < y + ratio)
                            break;

                        pixelChunk[i] = image.GetPixel(x, pixel);
                        i++;
                    }

                    compressedImage.SetPixel(x, y / ratio, CompressPixelChunk(pixelChunk, ratio));
                }
            }

            return compressedImage;
        }
    }
}
