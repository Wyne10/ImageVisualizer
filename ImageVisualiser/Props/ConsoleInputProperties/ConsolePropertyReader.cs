namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ConsolePropertyReader : IPropertyReader
    {
        public string ReadProperty(Property property)
        {
            Console.Write($"{Resources.ConsoleOutput.InitializationTag} {property.GetKey()}: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"{Resources.ConsoleOutput.ErrorTag} {Resources.ConsoleOutput.EmptyValueException}");
                input = ReadProperty(property);
            }

            return input;
        }
    }
}
