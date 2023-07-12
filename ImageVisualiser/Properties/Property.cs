namespace ImageVisualiser.Properties
{
    public abstract class Property
    {
        public readonly string key;
        public object? value { get; protected set; }

        protected Property(string key)
        {
            this.key = key;
        }

        public abstract object ReadProperty(string? input);

        public abstract string GetPropertyString();

        public PropertyType GetProperty<PropertyType>()
        {
            return (PropertyType)value;
        }
    }
}
