using ImageVisualiser.Properties.ConsoleInputProperties;

namespace ImageVisualiser.Properties
{
    public class ConsolePropertyReader
    {
        private readonly Dictionary<InputPropertyType, Property> _properties = new Dictionary<InputPropertyType, Property>()
        {
            { InputPropertyType.Image, new ImageFileProperty("Путь к изображению") }
        };

        public ConsolePropertyReader() 
        {
            InitializeProperties();
            Console.WriteLine("[ИНИЦИАЛИЗАЦИЯ] Инициализация успешно завершена, установленные настройки");
            OutputProperties();
        }

        public PropertyType GetProperty<PropertyType>(InputPropertyType propertyType)
        {
            return _properties[propertyType].GetProperty<PropertyType>();
        }

        private void InitializeProperties()
        {
            foreach (Property property in _properties.Values)
            {
                InitializeProperty(property);
            }
        }

        private void InitializeProperty(Property property)
        {
            Console.Write("[ИНИЦИAЛИЗАЦИЯ] {0}: ", property.key);
            string? input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("[ОШИБКА] Введённое значение не может быть пустым!");
                InitializeProperty(property);
                return;
            }

            if (property.ReadProperty(input) == null) 
            {
                InitializeProperty(property);
            }

            return;
        }

        private void OutputProperties()
        {
            foreach (Property property in _properties.Values)
            {
                Console.WriteLine("{0}: {1}", property.key, property.GetPropertyString());
            }
        }
    }

    public enum InputPropertyType
    {
        Image
    }
}
