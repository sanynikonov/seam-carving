using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SeamCarving
{
    public static class ColorMatrixExtensions
    {
        public static int Height(this Color[,] colors)
        {
            return colors.GetLength(0);
        }

        public static int Width(this Color[,] colors)
        {
            return colors.GetLength(1);
        }
    }
}
