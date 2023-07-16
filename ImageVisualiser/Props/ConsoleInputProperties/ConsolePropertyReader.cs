namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ConsolePropertyReader : IPropertyReader
    {
        public string ReadProperty(Property property)
        {
            Console.Write("[ИНИЦИAЛИЗАЦИЯ] {0}: ", property.GetKey());
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("[ОШИБКА] Введённое значение не может быть пустым!");
                input = ReadProperty(property);
            }

            return input;
        }
    }
}
