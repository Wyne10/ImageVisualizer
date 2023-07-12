using System.Drawing;

namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ImageFilePathProperty : Property
    {
        public ImageFilePathProperty(IPropertyReader reader, string key) : base(reader, key)
        { }

        public override string GetPropertyString()
        {
            return Value != null ? (string)Value : "";
        }

        public override object? InitializeProperty()
        {
            try
            {
                return Value = _propertyReader.ReadProperty(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ОШИБКА] {0}", ex.Message);
                return null;
            }
        }

    }
}
