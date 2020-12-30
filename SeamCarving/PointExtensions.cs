using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SeamCarving
{
    public static class PointExtensions
    {
        public static bool IsInRange(this Point point, int maxHeight, int maxWidth)
        {
            return point.X >= 0 && point.X < maxWidth && point.Y >= 0 && point.Y < maxHeight;
        }
    }
}
