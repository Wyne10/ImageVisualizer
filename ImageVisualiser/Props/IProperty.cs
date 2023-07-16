namespace ImageVisualiser.Props
{
    public interface IProperty
    {
        object? InitializeProperty();
        string GetKey();
        object? GetValue();
        PropertyType? GetProperty<PropertyType>();
    }
}
