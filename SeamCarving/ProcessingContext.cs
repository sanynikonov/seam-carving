using System.Collections.Generic;
using System.Drawing;

namespace SeamCarving
{
    public class ProcessingContext
    {
        public Color[,] Pixels { get; set; }
        public IEnumerable<Point> PointsOfShortestPath { get; set; }
        public Color[,] Result { get; set; }
    }
}