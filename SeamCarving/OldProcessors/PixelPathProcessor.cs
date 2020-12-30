using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving
{
    public class PixelPathProcessor : IImageProcessor
    {
        public Bitmap Process(Bitmap image)
        {
            var result = new Bitmap(image.Width, image.Height);

            var energies = new int[image.Height, image.Width];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    energies[y, x] = image.GetPixel(x, y).R; //RGB are equal, so no need to calculate average
                }
            }

            for (int y = 1; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var minEnergyAbove = GetEnergiesAbove(energies, y, x).Min();
                    energies[y, x] = energies[y, x] + minEnergyAbove;
                }
            }

            var maxEnergy = energies.Cast<int>().Max();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var rgb = energies[y, x] * 255 / maxEnergy;
                    var color = Color.FromArgb(rgb, rgb, rgb);
                    result.SetPixel(x, y, color);
                }
            }

            return result;
        }

        private int[] GetEnergiesAbove(int[,] energies, int y, int x)
        {
            var possiblePoints = new[] { new Point(x - 1, y - 1), new Point(x, y - 1), new Point(x + 1, y - 1) };

            return possiblePoints
                .Where(p => p.IsInRange(energies.GetLength(0), energies.GetLength(1)))
                .Select(p => energies[p.Y, p.X])
                .ToArray();
        }
    }
}
