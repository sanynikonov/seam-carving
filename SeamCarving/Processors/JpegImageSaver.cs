using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace SeamCarving.Processors
{
    public class JpegImageSaver : BaseProcessor
    {
        private readonly string _destination;
        private readonly int _width;
        private readonly int _height;

        public JpegImageSaver(string destination, int width, int height)
        {
            _destination = destination;
            _width = width;
            _height = height;
        }

        public override void Process(ProcessingContext context)
        {
            using var resultBitmap = BitmapConverter.FromColorsMatrix(context.Result);
            using var finalBitmap = new Bitmap(resultBitmap, new Size(_width, _height));

            finalBitmap.Save(_destination, ImageFormat.Jpeg);
        }
    }
}
