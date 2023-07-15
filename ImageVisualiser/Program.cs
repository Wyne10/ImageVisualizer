using ImageVisualiser.Props;

namespace ImageVisualiser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Properties.Instance.InitializeProperties();
            new ImageReader().VisualizeImage(Properties.Instance.GetProperty<string>(PropertyType.ImagePath),
                                            Properties.Instance.GetProperty<string>(PropertyType.OutputSymbol));
        }

    }
}