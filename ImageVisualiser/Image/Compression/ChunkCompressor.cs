using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public abstract class ChunkCompressor : ICompressor
    {
        public abstract Bitmap Compress(Bitmap image, int ratio);

        protected Color[] GetPixelChunk(int firstPixel, int ratio, Func<int, Color> getPixelFunc)
        {
            var pixelChunk = new Color[ratio];

            int i = 0;
            for (var currentPixel = firstPixel; currentPixel < firstPixel + ratio; currentPixel++)
            {
                pixelChunk[i] = getPixelFunc.Invoke(currentPixel);
                i++;
            }

            return pixelChunk;
        }

        protected Color CompressPixelChunk(Color[] pixelChunk, int ratio)
        {
            var compressedPixel = new int[3];

            foreach (Color pixelInChunk in pixelChunk)
            {
                compressedPixel[0] += pixelInChunk.R;
                compressedPixel[1] += pixelInChunk.G;
                compressedPixel[2] += pixelInChunk.B;
            }

            return Color.FromArgb(compressedPixel[0] / ratio, compressedPixel[1] / ratio, compressedPixel[2] / ratio);
        }
    }
}
