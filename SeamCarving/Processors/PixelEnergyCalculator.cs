using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving.Processors
{
    public class PixelEnergyCalculator : BaseProcessor
    {
        public override void Process(ProcessingContext context)
        {
            var pixels = context.Result ?? context.Pixels;

            var result = new Color[pixels.Height(), pixels.Width()];

            var energies = new int[pixels.Height(), pixels.Width()];

            for (int y = 0; y < pixels.Height(); y++)
            {
                for (int x = 0; x < pixels.Width(); x++)
                {
                    var pixel = pixels[y, x];

                    var neighbours = GetNeighbourPixels(pixels, x, y);

                    energies[y, x] = CalculateEnergy(pixel, neighbours);
                }
            }

            var maxEnergy = energies.Cast<int>().Max();

            for (int y = 0; y < pixels.Height(); y++)
            {
                for (int x = 0; x < pixels.Width(); x++)
                {
                    var rgb = energies[y, x] * 255 / maxEnergy;

                    var color = Color.FromArgb(rgb, rgb, rgb);
                    
                    result[y, x] = color;
                }
            }

            context.Result = result;
            ProcessNextIfNotNull(context);
        }

        private int CalculateEnergy(Color pixel, Color[] neighbours)
        {
            var midNeighboursValue = neighbours.Select(p => RgbSum(p)).Average();

            var pixelValue = RgbSum(pixel);

            var energy = Math.Abs((pixelValue - midNeighboursValue));

            return (int)energy;
        }

        private static int RgbSum(Color p)
        {
            return p.R + p.G + p.B;
        }

        private static Color[] GetNeighbourPixels(Color[,] pixels, int x, int y)
        {
            return GetNeigbourPoints(x, y)
                .Where(p => p.IsInRange(pixels.Height(), pixels.Width()))
                .Select(p => pixels[p.Y, p.X]).ToArray();
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
