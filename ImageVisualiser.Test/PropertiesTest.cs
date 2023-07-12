using ImageVisualiser.Properties.ConsoleInputProperties;

namespace ImageVisualiser.Test
{
    [TestFixture]
    public class PropertiesTest
    {
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\Dog.jpg")]
        public void ImageFilePropertyTest(string filePath)
        {
            ImageFileProperty imageFileProperty = new ImageFileProperty("");
            imageFileProperty.ReadProperty(filePath);
            Assert.IsNotNull(imageFileProperty.value);
        }
    }
}
