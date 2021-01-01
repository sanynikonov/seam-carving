using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace SeamCarving.Processors
{
    public class JpegImageSaver : BaseProcessor
    {
        private readonly int _width;
        private readonly int _height;

        public JpegImageSaver(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public override void Process(ProcessingContext context)
        {
            using var resultBitmap = BitmapConverter.FromColorsMatrix(context.Result);
            using var finalBitmap = new Bitmap(resultBitmap, new Size(_width, _height));

            finalBitmap.Save(context.DestinationFileName, ImageFormat.Jpeg);
        }
    }
}
