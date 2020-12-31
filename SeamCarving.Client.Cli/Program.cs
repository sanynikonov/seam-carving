using SeamCarving.Processors;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SeamCarving.Client.Cli
{
    class Program
    {
        private const string FullPath = @"C:\Users\nikon\Desktop\Test";
        private const string Folder = "VadymCrazy";
        private const string Picture = "Vadym1.jpg";

        static void Main(string[] args)
        {
            int pictures = 200;

            var horizontalenergyProcessor = new PixelEnergyCalculator();
            var horizontalpathProcessor = new HorizontalPixelPathsProcessor();
            var horizontalfinder = new HorizontalShortestPathFinder();
            var horizontalremoveProcessor = new HorizontalShortestPathRemover();

            var energyProcessor = new PixelEnergyCalculator();
            var pathProcessor = new PixelPathsProcessor();
            var finder = new Processors.ShortestPathFinder();
            var removeProcessor = new ShortestPathRemover();

            energyProcessor.SetNext(pathProcessor);
            pathProcessor.SetNext(finder);
            finder.SetNext(removeProcessor);

            horizontalenergyProcessor.SetNext(horizontalpathProcessor);
            horizontalpathProcessor.SetNext(horizontalfinder);
            horizontalfinder.SetNext(horizontalremoveProcessor);

            var startTime = DateTime.Now;

            using var file = Image.FromFile(Path.Combine(FullPath, Picture));

			var picturesWidth = file.Width - pictures / 2;
			var picturesHeight = file.Height - pictures / 2;

            Bitmap bitmap = new Bitmap(file);
            Bitmap source;

            //var energyProcessor = new PixelEnergyProcessor();
            //var pathProcessor = new PixelPathProcessor();
            //var finder = new ShortestPathFinder();
            //var removeProcessor = new RemoveShortestPathProcessor();

            var pixels = BitmapConverter.ToColorsMatrix(bitmap);
			bitmap.Dispose();
            ProcessingContext context;

            for (int i = 0; i < pictures; i++)
            {
                context = new ProcessingContext { Source = pixels };

                //source = new Bitmap(bitmap, new Size(file.Width, file.Height));

                //bitmap = energyProcessor.Process(source);

                //bitmap = pathProcessor.Process(bitmap);

                //var points = finder.FindShortestPath(bitmap);
                //removeProcessor.PointsOfShortestPath = points;

                //bitmap = removeProcessor.Process(source);

                if (i % 2 == 0)
                {
                    energyProcessor.Process(context);
                }
                else
                {
                    horizontalenergyProcessor.Process(context);
                }

                pixels = context.Result;

                var fileName = $"{i}.jpg";

                using var resultBitmap = BitmapConverter.FromColorsMatrix(context.Result);
                using var finalBitmap = new Bitmap(resultBitmap, new Size(picturesWidth, picturesHeight));

                finalBitmap.Save(Path.Combine(FullPath, Folder, fileName), ImageFormat.Jpeg);

                Console.WriteLine($"{fileName} was succesfully saved.");
            }

            var endTime = DateTime.Now;
            var difference = endTime - startTime;

            Console.WriteLine($"Processed in {difference.Minutes} m {difference.Seconds} s.");
        }
    }
}
