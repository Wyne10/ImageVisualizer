namespace ImageVisualiser.Properties
{
    public abstract class PropertyReader
    {
        public abstract void InitializeProperty(Property property);
        public void OutputProperty(Property property)
        {
            Console.WriteLine("{0}: {1}", property.key, property.GetPropertyString());
        }
    }
}
