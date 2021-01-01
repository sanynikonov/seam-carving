using SeamCarving.Builder;
using SeamCarving.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeamCarving.Client.WinForms
{
    public partial class MainForm : Form
    {
        private IProcessorBuilder _builder;
        private IProcessor _mainProcessor;

        public MainForm()
        {
            InitializeComponent();
            _builder = new ProcessorBuilder();
            _mainProcessor = _builder
                .SetPixelEnergyCalculator()
                .SetProcessor(context =>
                    gradientPictureBox.Image = BitmapConverter.FromColorsMatrix(context.Result))
                .SetPixelPathsProcessor(vertical: true)
                .SetProcessor(context =>
                    pixelPathPictureBox.Image = BitmapConverter.FromColorsMatrix(context.Result))
                .SetShortestPathFinder(vertical: true)
                .SetProcessor(MarkShortestPathAsRed)
                .SetProcessor(context =>
                    shortestPathPictureBox.Image = BitmapConverter.FromColorsMatrix(context.Result))
                .Build();
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            var source = sourcePictureBox.Image;

            var context = new ProcessingContext { Source = BitmapConverter.ToColorsMatrix(new Bitmap(source)) };

            _mainProcessor.Process(context);
        }

        private static void MarkShortestPathAsRed(ProcessingContext context)
        {
            var source = context.Source;
            var result = new Color[source.Height(), source.Width()];

            for (int y = 0; y < context.Result.Height(); y++)
            {
                for (int x = 0; x < context.Result.Width(); x++)
                {
                    if (context.PointsOfShortestPath.Contains(new Point(x, y)))
                    {
                        result[y, x] = Color.Red;
                        continue;
                    }

                    result[y, x] = source[y, x];
                }
            }

            context.Result = result;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourcePictureBox.Image.Dispose();
            gradientPictureBox.Image.Dispose();
        }
    }
}
