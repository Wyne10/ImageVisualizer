using System.Drawing;

namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ImageFileProperty : Property
    {
        private string? _imagePath;

        public ImageFileProperty(IPropertyReader reader, string key) : base(reader, key)
        { }

        public override string GetPropertyString()
        {
            return _imagePath ?? "";
        }

        public override object? InitializeProperty()
        {
            try
            {
                _imagePath = PropertyReader.ReadProperty(Key);
                Color[,] pixels;
                using (Bitmap image = new Bitmap(_imagePath))
                {
                    pixels = new Color[image.Width,image.Height];

                    for (var x = 0; x < pixels.GetLength(0); x++)
                    {
                        for (var y = 0; y < pixels.GetLength(1); y++)
                        {
                            pixels[x,y] = image.GetPixel(x, y);
                        }
                    }
                }
                return Value = pixels;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ОШИБКА] {0}", ex.Message);
                return null;
            }
        }

    }
}
