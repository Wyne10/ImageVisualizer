namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ConsoleStringProperty : Property
    {
        public ConsoleStringProperty(IPropertyReader propertyReader, string key) : base(propertyReader, key)
        { }

        public override string ToString()
        {
            return Value != null ? (string)Value : "";
        }

        public override object? InitializeProperty()
        {
            try
            {
                return Value = PropertyReader.ReadProperty(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Resources.ConsoleOutput.ErrorTag} {ex.Message}");
                return null;
            }
        }
    }
}
