using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SeamCarving
{
    public class ProcessingContext
    {
        public Color[,] Source { get; set; }
        public IEnumerable<Point> PointsOfShortestPath { get; set; }
        public Color[,] Result { get; set; }
        public string DestinationFileName { get; set; }
    }
}