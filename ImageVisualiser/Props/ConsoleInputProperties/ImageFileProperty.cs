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
            return _imagePath;
        }

        public override object? InitializeProperty()
        {
            try
            {
                string input = _propertyReader.ReadProperty(this);
                Value = new Bitmap(input);
                _imagePath = input;
                return Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ОШИБКА] {0}", ex.Message);
                return null;
            }
        }


    }
}
