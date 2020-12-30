using System;
using System.Drawing;
using System.IO;

namespace SeamCarving.Client.Cli
{
    class Program
    {
        private const string FullPath = @"C:\Users\nikon\Desktop\Test";
        private const string Folder = "Pictures";
        private const string Picture = "Жека.png";

        static void Main(string[] args)
        {
            int pictures = 10;

            using var file = Image.FromFile(Path.Combine(FullPath, Picture));

            Bitmap bitmap = new Bitmap(file);
            Bitmap source;

            var energyProcessor = new PixelEnergyProcessor();
            var pathProcessor = new PixelPathProcessor();
            var finder = new ShortestPathFinder();
            var removeProcessor = new RemoveShortestPathProcessor();

            for (int i = 0; i < pictures; i++)
            {
                source = new Bitmap(bitmap, new Size(file.Width, file.Height));

                bitmap = energyProcessor.Process(source);

                bitmap = pathProcessor.Process(bitmap);

                var points = finder.FindShortestPath(bitmap);
                removeProcessor.PointsOfShortestPath = points;

                bitmap = removeProcessor.Process(source);

                var fileName = $"{i}.png";

                bitmap.Save(Path.Combine(FullPath, Folder, fileName));

                Console.WriteLine($"{fileName} was succesfully saved.");
            }
        }
    }
}
