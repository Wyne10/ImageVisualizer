﻿using ImageVisualiser.Props.ConsoleInputProperties;

namespace ImageVisualiser.Test
{
    [TestFixture]
    public class PropsTest
    {
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\Dog.jpg")]
        public void ImageFilePropertyTest(string filePath)
        {
            StringProperty imageFileProperty = new StringProperty(new ConsolePropertyReader(), "Путь к изображению");
            Console.SetIn(new StringReader(filePath));
            imageFileProperty.InitializeProperty();
            Assert.IsNotNull(imageFileProperty.Value);
        }
    }
}
