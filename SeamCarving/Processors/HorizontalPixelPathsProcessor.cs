﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SeamCarving.Processors
{
    public class HorizontalPixelPathsProcessor : BaseProcessor
    {
        public override void Process(ProcessingContext context)
        {
            var pixels = context.Result ?? context.Source;

            var result = new Color[pixels.Height(), pixels.Width()];

            var energies = new int[pixels.Height(), pixels.Width()];

            for (int y = 0; y < pixels.Height(); y++)
            {
                for (int x = 0; x < pixels.Width(); x++)
                {
                    energies[y, x] = pixels[y, x].R; //RGB are equal, so no need to calculate average
                }
            }

            for (int y = 0; y < pixels.Height(); y++)
            {
                for (int x = 1; x < pixels.Width(); x++)
                {
                    var minEnergyLeft = GetEnergiesLeft(energies, y, x).Min();
                    energies[y, x] = energies[y, x] + minEnergyLeft;
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

        private int[] GetEnergiesLeft(int[,] energies, int y, int x)
        {
            var possiblePoints = new[] { new Point(x - 1, y - 1), new Point(x - 1, y), new Point(x - 1, y + 1) };

            return possiblePoints
                .Where(p => p.IsInRange(energies.GetLength(0), energies.GetLength(1)))
                .Select(p => energies[p.Y, p.X])
                .ToArray();
        }
    }
}
