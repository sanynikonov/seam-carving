using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving.Processors
{
    public class HorizontalShortestPathRemover : BaseProcessor
    {
        public override void Process(ProcessingContext context)
        {
            if (context.PointsOfShortestPath == null)
                throw new InvalidOperationException("Unable to remove shortest path without provided coodinates.");

            var image = context.Source;

            var result = new Color[image.Height() - 1, image.Width()];

            int currentX = 0;
            int currentY = 0;

            for (int x = 0; x < image.Width(); x++)
            {                
                for (int y = 0; y < image.Height(); y++)
                {
                    if (context.PointsOfShortestPath.Contains(new Point(x, y)))
                    {
                        continue;
                    }

                    result[currentY++, currentX] = image[y, x];
                }

                currentX++;
                currentY = 0;
            }

            context.Result = result;
            ProcessNextIfNotNull(context);
        }
    }
}
