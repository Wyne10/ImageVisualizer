using System.Drawing;

namespace ImageVisualiser.Properties.ConsoleInputProperties
{
    public class ImageFileProperty : Property
    {
        private string _imagePath;

        public ImageFileProperty(string key) : base(key)
        { }

        public override string GetPropertyString()
        {
            return _imagePath;
        }

        public override object ReadProperty(string? input)
        {
            try
            {
                value = new Bitmap(input);
                _imagePath = input;
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ОШИБКА] {0}", ex.Message);
                return null;
            }
        }


    }
}
