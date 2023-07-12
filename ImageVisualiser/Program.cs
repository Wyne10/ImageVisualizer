using ImageVisualiser.Properties;
using System.Drawing;

namespace ImageVisualiser
{
    public class Program
    {
        public static ConsolePropertyReader InputProperties { get; private set; }

        public static void Main(string[] args)
        {
            InitializeProperties();
            var ImageReader = new ImageReader();
            ImageReader.VisualizeImage(InputProperties.GetProperty<Bitmap>(InputPropertyType.Image));
        }

        private static void InitializeProperties()
        {
            InputProperties = new ConsolePropertyReader();
        }

    }
}