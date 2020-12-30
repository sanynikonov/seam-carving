using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving
{
    public class MarkShortestPathRedProcessor : IImageProcessor
    {
        public IEnumerable<Point> PointsOfShortestPath { get; set; }

        public Bitmap Process(Bitmap image)
        {
            var result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (PointsOfShortestPath.Contains(new Point(x, y)))
                    {
                        result.SetPixel(x, y, Color.Red);
                        continue;
                    }

                    result.SetPixel(x, y, image.GetPixel(x, y));
                }
            }

            return result;
        }
    }
}
