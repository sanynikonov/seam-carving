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
        private const string Folder = "Me";
        private const string Picture = "Me.png";

        static void Main(string[] args)
        {
            int pictures = 300;

            IProcessorBuilder builder = new ProcessorBuilder();

            using var file = Image.FromFile(Path.Combine(FullPath, Picture));
            var bitmap = new Bitmap(file);
            var source = BitmapConverter.ToColorsMatrix(bitmap);
            bitmap.Dispose();

            var picturesWidth = source.Width() - pictures / 2;
            var picturesHeight = source.Height() - pictures / 2;

            var horizontalenergyProcessor = builder
                .SetDefaultHorizontalConveyor()
                //.SetJpegImageSaver(picturesWidth, picturesHeight)
                .Build();

            builder.Reset();

            var energyProcessor = builder
                 .SetDefaultVerticalConveyor()
                 //.SetJpegImageSaver(picturesWidth, picturesHeight)
                 .Build();

            ProcessingContext context;
            string filename;
            string fileDestination;

            using var gifWriter = new GifWriter(Path.Combine(FullPath, $"{Picture}.gif"), DefaultFrameDelay: 25, Repeat: 0);

            var startTime = DateTime.Now;

            for (int i = 0; i < pictures; i++)
            {
                filename = $"{i}";
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

                using var resultBitmap = BitmapConverter.FromColorsMatrix(context.Result);
                using var finalBitmap = new Bitmap(resultBitmap, new Size(picturesWidth, picturesHeight));
                gifWriter.WriteFrame(finalBitmap);

                Console.WriteLine($"{filename} frame was succesfully saved.");
            }

            var endTime = DateTime.Now;
            var difference = endTime - startTime;

            Console.WriteLine($"Processed in {difference.Minutes} m {difference.Seconds} s.");
        }
    }
}
