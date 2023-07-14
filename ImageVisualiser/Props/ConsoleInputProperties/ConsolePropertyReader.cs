namespace ImageVisualiser.Props.ConsoleInputProperties
{
    public class ConsolePropertyReader : IPropertyReader
    {
        public string ReadProperty(string propertyKey)
        {
            Console.Write("[ИНИЦИAЛИЗАЦИЯ] {0}: ", propertyKey);
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("[ОШИБКА] Введённое значение не может быть пустым!");
                input = ReadProperty(propertyKey);
            }

            return input;
        }
    }
}
