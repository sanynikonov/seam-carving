using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving
{
    public class ShortestPathFinder
    {
        public IEnumerable<Point> FindShortestPath(Bitmap image)
        {
            var result = new List<Point>();

            var energies = new int[image.Height][];

            for (int i = 0; i < energies.Length; i++)
            {
                energies[i] = new int[image.Width];
            }

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    energies[y][x] = image.GetPixel(x, y).R; //RGB are equal, so no need to calculate average
                }
            }

            var indexY = energies.Length - 1;
            var minEnergyX = Array.IndexOf(energies[indexY], energies[indexY].Min());
            result.Add(new Point(minEnergyX, indexY));

            while (--indexY >= 0)
            {
                var energiesAbove = GetEnergiesAbove(energies, indexY + 1, minEnergyX);

                var minEnergyAbove = energiesAbove.Select(p => energies[p.Y][p.X]).Min();

                minEnergyX = energiesAbove.First(p => energies[p.Y][p.X] == minEnergyAbove).X;

                result.Add(new Point(minEnergyX, indexY));
            }

            return result;
        }

        private Point[] GetEnergiesAbove(int[][] energies, int y, int x)
        {
            var possiblePoints = new[] { new Point(x - 1, y - 1), new Point(x, y - 1), new Point(x + 1, y - 1) };

            return possiblePoints
                .Where(p => p.IsInRange(energies[0].Length, energies.Length))
                .ToArray();
        }
    }
}
