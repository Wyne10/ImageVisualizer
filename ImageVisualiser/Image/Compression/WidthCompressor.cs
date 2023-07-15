using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public class WidthCompressor : Compressor
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
                    var pixelChunk = new Color[ratio];

                    int i = 0;
                    for (var pixel = x; pixel < x + ratio; pixel++)
                    {
                        if (image.Width < x + ratio)
                            break;

                        pixelChunk[i] = image.GetPixel(pixel, y);
                        i++;
                    }

                    compressedImage.SetPixel(x / ratio, y, CompressPixelChunk(pixelChunk, ratio));
                }
            }

            return compressedImage;
        }
    }
}
