using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving
{
    public class RemoveShortestPathProcessor : IImageProcessor
    {
        public IEnumerable<Point> PointsOfShortestPath { get; set; }

        public Bitmap Process(Bitmap image)
        {
            var result = new Bitmap(image.Width - 1, image.Height);

            int newX = 0;
            int newY = 0;

            var pixels = new Color[image.Height][];

            for (int y = 0; y < image.Height; y++)
            {
                pixels[y] = new Color[image.Width];
                for (int x = 0; x < image.Width; x++)
                {
                    pixels[y][x] = image.GetPixel(x, y);
                }
            }

            var colors = pixels
                .Select((arr, y) =>
                    arr.Where((c, x) =>
                        !PointsOfShortestPath.Contains(new Point(x, y)))
                    .ToArray())
                .ToArray();

            for (int y = 0; y < result.Height; y++)
            {
                for (int x = 0; x < result.Width; x++)
                {
                    result.SetPixel(x, y, colors[y][x]);
                }
            }

            //for (int y = 0; y < image.Height; y++)
            //{
            //    for (int x = 0; x < image.Width; x++)
            //    {
            //        if (PointsOfShortestPath.Contains(new Point(x, y)))
            //        {
            //            continue;
            //        }

            //        result.SetPixel(newX, newY, image.GetPixel(x, y));

            //        newX++;
            //        newY++;
            //    }

            //    newX = 0;
            //    newY = 0;
            //}

            return result;
        }

    }
}
