using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SeamCarving
{
    public class PixelEnergyProcessor : IImageProcessor
    {
        public Bitmap Process(Bitmap image)
        {
            var result = new Bitmap(image.Width, image.Height);

            var energies = new int[image.Height, image.Width];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);

                    var neighbours = GetNeighbourPixels(image, x, y);

                    energies[y, x] = CalculateEnergy(pixel, neighbours);
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

        private int CalculateEnergy(Color pixel, Color[] neighbours)
        {
            var midNeighboursValue = neighbours.Select(p => RgbSum(p)).Average();

            var pixelValue = RgbSum(pixel);

            var energy = Math.Abs((pixelValue - midNeighboursValue));

            return (int)energy;
        }

        private static Color CreateEnergyColor(Color pixel, Color[] neighbours)
        {
            var midNeighboursValue = neighbours.Select(p => RgbSum(p)).Average();

            var pixelValue = RgbSum(pixel);

            var energy = (int)Math.Abs((pixelValue - midNeighboursValue) / 3);

            var energyColor = Color.FromArgb(energy, energy, energy);
            return energyColor;
        }

        private static Color CreateEnergyColor1(Color pixel, Color[] neighbours)
        {
            var midNeighboursR = neighbours.Select(p => (int)p.R).Average();
            var midNeighboursG = neighbours.Select(p => (int)p.G).Average();
            var midNeighboursB = neighbours.Select(p => (int)p.B).Average();

            var energyR = (int)Math.Abs(pixel.R - midNeighboursR);
            var energyG = (int)Math.Abs(pixel.G - midNeighboursG);
            var energyB = (int)Math.Abs(pixel.B - midNeighboursB);

            var energyColor = Color.FromArgb(energyR, energyG, energyB);
            return energyColor;
        }

        private static int RgbSum(Color p)
        {
            return p.R + p.G + p.B;
        }

        private static Color[] GetNeighbourPixels(Bitmap image, int x, int y)
        {
            return GetNeigbourPoints(x, y)
                .Where(p => p.IsInRange(image.Height, image.Width))
                .Select(p => image.GetPixel(p.X, p.Y)).ToArray();
        }

        private static Point[] GetNeigbourPoints(int x, int y)
        {
            return new[]
            {
                new Point(x - 1, y),
                new Point(x + 1, y),
                new Point(x, y - 1),
                new Point(x, y + 1),
            };
        }
    }
}
