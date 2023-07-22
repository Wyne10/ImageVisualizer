using ImageVisualiser.Image.Compression;
using System.Drawing;

namespace ImageVisualiser
{
    public static class ImageReader
    {
        public static void VisualizeImage(string imagePath, string outputSymbol, uint compressionRatio)
        {
            using (Bitmap bmp = new Bitmap(imagePath)) 
            {
                using (Bitmap compressedBmp = new ScaleCompressor().Compress(bmp, (int)compressionRatio))
                for (var y = 0; y < compressedBmp.Height; y++)
                {
                    for (var x = 0; x < compressedBmp.Width; x++)
                    {
                        Color pixelColor = compressedBmp.GetPixel(x, y);
                        if (pixelColor.A < 255)
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else
                            Console.ForegroundColor = ImageReader.ClosestConsoleColor(pixelColor.R, pixelColor.G, pixelColor.B);
                        Console.Write(outputSymbol);
                    }
                    Console.Write("\n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // https://stackoverflow.com/questions/65357313/change-consolecolor-to-a-hex-value
        private static ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor result = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n);
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    result = cc;
                }
            }
            return result;
        }
    }
}
