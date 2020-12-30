using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SeamCarving
{
    public class BitmapConverter
    {
        public static Color[,] ToColorsMatrix(Bitmap image)
        {
            var pixels = new Color[image.Height, image.Width];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    pixels[y, x] = image.GetPixel(x, y);
                }
            }

            return pixels;
        }

        public static Bitmap FromColorsMatrix(Color[,] colors)
        {
            var bitmap = new Bitmap(colors.Width(), colors.Height());

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    bitmap.SetPixel(x, y, colors[y, x]);
                }
            }

            return bitmap;
        }
    }
}
