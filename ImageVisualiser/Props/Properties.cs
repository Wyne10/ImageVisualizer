using ImageVisualiser.Props.ConsoleInputProperties;

namespace ImageVisualiser.Props
{
    public class Properties
    {
        public static readonly Properties Instance = new Properties();

        public static readonly IPropertyReader ConsolePropertyReader = new ConsolePropertyReader();

        public static readonly Dictionary<PropertyType, IProperty> PropertyList = new Dictionary<PropertyType, IProperty>()
        {
            { PropertyType.ImagePath, new ConsoleStringProperty(ConsolePropertyReader, Resources.ConsoleOutput.ImagePathPropertyKey) },
            { PropertyType.CompressionRatio, new ConsoleUIntProperty(ConsolePropertyReader, Resources.ConsoleOutput.CompressionRatioPropertyKey) },
            { PropertyType.OutputSymbol, new ConsoleStringProperty(ConsolePropertyReader, Resources.ConsoleOutput.OutputSymbolPropertyKey) }
        };

        public void InitializeProperties()
        {
            foreach (IProperty property in PropertyList.Values)
            {
                property.InitializeProperty();
            }

            Console.WriteLine($"\n{Resources.ConsoleOutput.InitializationTag} {Resources.ConsoleOutput.SuccessfulInitialization}");
            foreach (IProperty property in PropertyList.Values)
            {
                Console.WriteLine($"{property.GetKey()}: {property.ToString()}");
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
        OutputSymbol,
        CompressionRatio
    }
}
