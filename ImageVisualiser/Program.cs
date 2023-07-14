using ImageVisualiser.Props;
using System.Drawing;

namespace ImageVisualiser
{
    public class Program
    {
        public static Properties Properties { get; private set; } = new Properties();

        public static void Main(string[] args)
        {
            Properties.InitializeProperties();
            new ImageReader().VisualizeImage(new Bitmap(Properties.GetProperty<string>(PropertyType.ImagePath)));
        }

    }
}