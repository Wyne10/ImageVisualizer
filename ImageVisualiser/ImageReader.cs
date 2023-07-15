using ImageVisualiser.Props;
using System.Drawing;

namespace ImageVisualiser
{
    public class ImageReader
    {
        public ImageReader() { }

        public void VisualizeImage(string imagePath, string outputSymbol)
        {
            using (Bitmap bmp = new Bitmap(imagePath)) 
            {
                for (var y = 0; y < bmp.Height; y++)
                {
                    for (var x = 0; x < bmp.Width; x++)
                    {
                        Color pixelColor = bmp.GetPixel(x, y);
                        if (pixelColor.A < 255)
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else
                            Console.ForegroundColor = ClosestConsoleColor(pixelColor.R, pixelColor.G, pixelColor.B);
                        Console.Write(outputSymbol);
                    }
                    Console.Write("\n");
                }
            }
        }

        private ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor result = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
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
