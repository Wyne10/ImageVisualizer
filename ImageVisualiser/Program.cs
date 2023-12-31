﻿using ImageVisualiser.Props;
using System.Globalization;

namespace ImageVisualiser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Properties.Instance.InitializeProperties();
            ImageReader.VisualizeImage(Properties.Instance.GetProperty<string>(PropertyType.ImagePath),
                                            Properties.Instance.GetProperty<string>(PropertyType.OutputSymbol),
                                            Properties.Instance.GetProperty<uint>(PropertyType.CompressionRatio));
        }

    }
}