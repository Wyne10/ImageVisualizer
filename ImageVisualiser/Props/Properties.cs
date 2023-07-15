using ImageVisualiser.Props.ConsoleInputProperties;

namespace ImageVisualiser.Props
{
    public class Properties
    {
        public static readonly Properties Instance = new Properties();

        public static readonly IPropertyReader ConsolePropertyReader = new ConsolePropertyReader();

        public static readonly Dictionary<PropertyType, Property> PropertyList = new Dictionary<PropertyType, Property>()
        {
            { PropertyType.ImagePath, new StringProperty(ConsolePropertyReader, "Путь к изображению") },
            { PropertyType.OutputSymbol, new StringProperty(ConsolePropertyReader, "Символ для визуализации") }
        };

        public void InitializeProperties()
        {
            foreach (Property property in PropertyList.Values)
            {
                property.InitializeProperty();
            }

            Console.WriteLine("[ИНИЦИАЛИЗАЦИЯ] Инициализация успешно завершена, установленные параметры");
            foreach (Property property in PropertyList.Values)
            {
                Console.WriteLine("{0}: {1}", property.Key, property.GetPropertyString());
            }
        }

        public TPropertyType? GetProperty<TPropertyType>(PropertyType type)
        {
            PropertyList.TryGetValue(type, out var property);
            return property != null ? property.GetProperty<TPropertyType>() : default(TPropertyType);
        }
    }

    public enum PropertyType
    {
        ImagePath,
        OutputSymbol
    }
}
