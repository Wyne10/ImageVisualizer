using ImageVisualiser.Image.Compression;
using System.Drawing;

namespace ImageVisualiser.Test
{
    [TestFixture]
    public class CompressionTest
    {
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogWidthCompressed2x.jpg", 2)]
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogWidthCompressed3x.jpg", 3)]
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogWidthCompressed16x.jpg", 16)]
        public void WidthCompressionTest(string imagePath, string outputPath, int ratio)
        {
            ICompressor compressor = new WidthCompressor();
            
            using(Bitmap image = new Bitmap(imagePath)) 
            {
                using (Bitmap compressedImage = compressor.Compress(image, ratio))
                {
                    compressedImage.Save(outputPath);
                }
            }
        }

        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogHeightCompressed2x.jpg", 2)]
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogHeightCompressed3x.jpg", 3)]
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogHeightCompressed16x.jpg", 16)]
        public void HeightCompressionTest(string imagePath, string outputPath, int ratio)
        {
            ICompressor compressor = new HeightCompressor();

            using (Bitmap image = new Bitmap(imagePath))
            {
                using (Bitmap compressedImage = compressor.Compress(image, ratio))
                {
                    compressedImage.Save(outputPath);
                }
            }
        }

        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogCompressed2x.jpg", 2)]
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogCompressed3x.jpg", 3)]
        [TestCase(@"F:\Coding\C#\ImageVisualiser\Resources\BetterDog.jpg", @"F:\Coding\C#\ImageVisualiser\Resources\BetterDogCompressed16x.jpg", 16)]
        public void ScaleCompressionTest(string imagePath, string outputPath, int ratio)
        {
            ICompressor compressor = new ScaleCompressor();

            using (Bitmap image = new Bitmap(imagePath))
            {
                using (Bitmap compressedImage = compressor.Compress(image, ratio))
                {
                    compressedImage.Save(outputPath);
                }
            }
        }
    }
}
