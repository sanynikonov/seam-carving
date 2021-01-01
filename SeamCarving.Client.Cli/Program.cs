using SeamCarving.Builder;
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
        private const string Folder = "Yarik";
        private const string Picture = "Yarik.jpg";

        static void Main(string[] args)
        {
            int pictures = 300;

            IProcessorBuilder builder = new ProcessorBuilder();

            using var file = Image.FromFile(Path.Combine(FullPath, Picture));
            var bitmap = new Bitmap(file, new Size(450, 450));
            var source = BitmapConverter.ToColorsMatrix(bitmap);
            bitmap.Dispose();

            var picturesWidth = 300;
            var picturesHeight = 300;

            var horizontalenergyProcessor = builder
                .SetDefaultHorizontalConveyor()
                .SetJpegImageSaver(picturesWidth, picturesHeight)
                .Build();

            builder.Reset();

            var energyProcessor = builder
                 .SetDefaultVerticalConveyor()
                 .SetJpegImageSaver(picturesWidth, picturesHeight)
                 .Build();

            ProcessingContext context;
            string filename;
            string fileDestination;

            var startTime = DateTime.Now;

            for (int i = 0; i < pictures; i++)
            {
                filename = $"{i}.jpg";
                fileDestination = Path.Combine(FullPath, Folder, filename);

                context = new ProcessingContext { Source = source, DestinationFileName = fileDestination };

                if (i % 2 == 0)
                {
                    energyProcessor.Process(context);
                }
                else
                {
                    horizontalenergyProcessor.Process(context);
                }

                source = context.Result;

                Console.WriteLine($"{filename} was succesfully saved.");
            }

            var endTime = DateTime.Now;
            var difference = endTime - startTime;

            Console.WriteLine($"Processed in {difference.Minutes} m {difference.Seconds} s.");
        }
    }
}
