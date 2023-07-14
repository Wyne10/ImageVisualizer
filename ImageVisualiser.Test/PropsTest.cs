using ImageVisualiser.Props;
using ImageVisualiser.Props.ConsoleInputProperties;
using System.Drawing;

namespace ImageVisualiser.Test
{
    [TestFixture]
    public class PropsTest
    {
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\Dog.jpg")]
        public void ImageFilePropertyTest(string filePath)
        {
            ImageFileProperty imageFileProperty = new ImageFileProperty(new ConsolePropertyReader(), "Путь к изображению");
            Console.SetIn(new StringReader(filePath));
            imageFileProperty.InitializeProperty();
            Assert.IsNotNull(imageFileProperty.Value);
        }
    }
}
