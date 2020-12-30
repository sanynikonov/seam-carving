using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving.Processors
{
    public class HorizontalShortestPathFinder : BaseProcessor
    {
        public override void Process(ProcessingContext context)
        {
            var image = context.Result ?? context.Source;

            var result = new List<Point>();

            var energies = new int[image.Height()][];

            for (int i = 0; i < energies.Length; i++)
            {
                energies[i] = new int[image.Width()];
            }

            for (int y = 0; y < image.Height(); y++)
            {
                for (int x = 0; x < image.Width(); x++)
                {
                    energies[y][x] = image[y, x].R; //RGB are equal, so no need to calculate average
                }
            }

            var indexX = energies[0].Length - 1;
            var minEnergyIndexY = energies.Select((arr) => arr[indexX]).Min();

            result.Add(new Point(indexX, minEnergyIndexY));

            while (--indexX >= 0)
            {
                var energiesLeftPoints = GetEnergiesLeft(energies, minEnergyIndexY, indexX + 1);

                var minEnergyLeft = energiesLeftPoints.Select(p => energies[p.Y][p.X]).Min();

                minEnergyIndexY = energiesLeftPoints.First(p => energies[p.Y][p.X] == minEnergyLeft).Y;

                result.Add(new Point(indexX, minEnergyIndexY));
            }

            context.PointsOfShortestPath = result;
            ProcessNextIfNotNull(context);
        }

        private Point[] GetEnergiesLeft(int[][] energies, int y, int x)
        {
            var possiblePoints = new[] { new Point(x - 1, y - 1), new Point(x - 1, y), new Point(x - 1, y + 1) };

            return possiblePoints
                .Where(p => p.IsInRange(energies.Length, energies[0].Length))
                .ToArray();
        }
    }
}
