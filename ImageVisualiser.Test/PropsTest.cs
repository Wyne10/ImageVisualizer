using ImageVisualiser.Props;
using ImageVisualiser.Props.ConsoleInputProperties;

namespace ImageVisualiser.Test
{
    [TestFixture]
    public class PropsTest
    {
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\Dog.jpg")]
        public void StringPropertyTest(string filePath)
        {
            IProperty imageFileProperty = new ConsoleStringProperty(new ConsolePropertyReader(), "Путь к изображению");
            Console.SetIn(new StringReader(filePath));
            imageFileProperty.InitializeProperty();
            Assert.That(imageFileProperty.GetProperty<string>().Equals(filePath));
        }

        [TestCase(5)]
        public void UIntPropertyTest(int assert)
        {
            IProperty compressionRatioProperty = new ConsoleUIntProperty(new ConsolePropertyReader(), "Степень сжатия изображения");
            Console.SetIn(new StringReader(assert.ToString()));
            compressionRatioProperty.InitializeProperty();
            Assert.That(compressionRatioProperty.GetProperty<uint>().Equals(5));
        }
    }
}
