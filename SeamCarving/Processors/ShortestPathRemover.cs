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

            int currentX = 0;
            int currentY = 0;

            for (int y = 0; y < image.Width(); y++)
            {
                for (int x = 0; x < image.Height(); x++)
                {
                    if (context.PointsOfShortestPath.Contains(new Point(x, y)))
                    {
                        continue;
                    }

                    result[currentY, currentX++] = image[y, x];
                }

                currentX = 0;
                currentY++;
            }

            context.Result = result;
            ProcessNextIfNotNull(context);
        }
    }
}
