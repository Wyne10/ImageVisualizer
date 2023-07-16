namespace ImageVisualiser.Props
{
    public abstract class Property : IProperty
    {
        protected readonly IPropertyReader PropertyReader;
        private readonly string _key;
        protected object? Value { get; set; }

        protected Property(IPropertyReader propertyReader, string key)
        {
            PropertyReader = propertyReader;
            _key = key;
        }

        public abstract object? InitializeProperty();

        public abstract override string ToString();

        public virtual PropertyType? GetProperty<PropertyType>()
        {
            return Value != null ? (PropertyType)Value : default(PropertyType);
        }

        public string GetKey()
        {
            return _key;
        }

        public object? GetValue()
        {
            return Value;
        }
    }
}
