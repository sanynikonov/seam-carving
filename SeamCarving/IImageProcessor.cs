using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SeamCarving
{
    public interface IImageProcessor
    {
        Bitmap Process(Bitmap image);
    }
}
