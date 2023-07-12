using ImageVisualiser.Props.ConsoleInputProperties;

namespace ImageVisualiser.Props
{
    public class Properties
    {
        private readonly ConsolePropertyReader _consolePropertyReader = new ConsolePropertyReader();

        private readonly Dictionary<PropertyType, Property> _properties;

        public Properties() 
        {
            _properties = new Dictionary<PropertyType, Property>()
            {
                { PropertyType.ImagePath, new ImageFilePathProperty(_consolePropertyReader, "Путь к изображению") }
            };
        }

        public void InitializeProperties()
        {
            foreach (Property property in _properties.Values)
            {
                property.InitializeProperty();
            }

            Console.WriteLine("[ИНИЦИАЛИЗАЦИЯ] Инициализация успешно завершена, установленные параметры");
            foreach (Property property in _properties.Values)
            {
                Console.WriteLine("{0}: {1}", property.Key, property.GetPropertyString());
            }
        }

        public TPropertyType? GetProperty<TPropertyType>(PropertyType type)
        {
            _properties.TryGetValue(type, out var property);
            return property != null ? property.GetProperty<TPropertyType>() : default(TPropertyType);
        }
    }

    public enum PropertyType
    {
        ImagePath
    }
}
