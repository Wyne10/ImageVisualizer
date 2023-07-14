namespace ImageVisualiser.Props
{
    public abstract class Property
    {
        protected readonly IPropertyReader PropertyReader;
        public readonly string Key;
        public object? Value { get; protected set; }

        protected Property(IPropertyReader propertyReader, string key)
        {
            PropertyReader = propertyReader;
            Key = key;
        }

        public abstract object? InitializeProperty();

        public abstract string GetPropertyString();

        public virtual PropertyType GetProperty<PropertyType>()
        {
            return (PropertyType)Value;
        }
    }
}
