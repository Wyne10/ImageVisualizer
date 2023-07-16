﻿namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ConsoleStringProperty : Property
    {
        public ConsoleStringProperty(IPropertyReader propertyReader, string key) : base(propertyReader, key)
        { }

        public override string GetPropertyString()
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
                Console.WriteLine("[ОШИБКА] {0}", ex.Message);
                return null;
            }
        }
    }
}