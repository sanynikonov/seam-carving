using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving.Processors
{
    public class ShortestPathRemover : BaseProcessor
    {
        public override void Process(ProcessingContext context)
        {
            if (context.PointsOfShortestPath == null)
                throw new InvalidOperationException("Unable to remove shortest path without provided coodinates.");

            var image = context.Source;

            var result = new Color[image.Height(), image.Width() - 1];

            var pixels = new Color[image.Height()][];

            for (int y = 0; y < image.Height(); y++)
            {
                pixels[y] = new Color[image.Width()];
                for (int x = 0; x < image.Width(); x++)
                {
                    pixels[y][x] = image[y, x];
                }
            }

            var colors = pixels
                .Select((arr, y) =>
                    arr.Where((c, x) =>
                        !context.PointsOfShortestPath.Contains(new Point(x, y)))
                    .ToArray())
                .ToArray();

            for (int y = 0; y < result.Height(); y++)
            {
                for (int x = 0; x < result.Width(); x++)
                {
                    result[y, x] = colors[y][x];
                }
            }

            context.Result = result;
            ProcessNextIfNotNull(context);
        }
    }
}
