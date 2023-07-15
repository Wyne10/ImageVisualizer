using System.Drawing;

namespace ImageVisualiser.Image.Compression
{
    public interface ICompressor
    { 
        Bitmap Compress(Bitmap image, int ratio);
    }
}
