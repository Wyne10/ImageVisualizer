namespace ImageVisualiser.Props
{
    public abstract class Property
    {
        protected readonly IPropertyReader _propertyReader;
        public readonly string Key;
        public object? Value { get; protected set; }

        protected Property(IPropertyReader reader, string key)
        {
            _propertyReader = reader;
            Key = key;
        }

        public abstract object? InitializeProperty();

        public abstract string GetPropertyString();

        public PropertyType GetProperty<PropertyType>()
        {
            return (PropertyType)Value;
        }
    }
}
