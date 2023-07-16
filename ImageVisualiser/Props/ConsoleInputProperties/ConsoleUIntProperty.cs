namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ConsoleUIntProperty : Property
    {
        public ConsoleUIntProperty(IPropertyReader propertyReader, string key) : base(propertyReader, key)
        { }

        public override string ToString()
        {
            return ((uint)Value).ToString();
        }

        public override object? InitializeProperty()
        {
            try
            {
                uint value;
                bool result = UInt32.TryParse(PropertyReader.ReadProperty(this), out value);
                if (result == false)
                {
                    Console.WriteLine("[ОШИБКА] Нужно ввести неотрицательное число!");
                    value = (uint)InitializeProperty();
                }
                return Value = value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ОШИБКА] {0}", ex.Message);
                return null;
            }
        }
    }
}
