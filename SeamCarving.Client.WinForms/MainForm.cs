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
        private PixelEnergyProcessor processor = new PixelEnergyProcessor();
        private PixelPathProcessor pathProcessor = new PixelPathProcessor();
        private MarkShortestPathRedProcessor shortestPathMarker = new MarkShortestPathRedProcessor();
        private RemoveShortestPathProcessor removeShortestPathProcessor = new RemoveShortestPathProcessor();

        private ShortestPathFinder shortestPathFinder = new ShortestPathFinder();
        Point[] points;

        public MainForm()
        {
            InitializeComponent();
            //points = Enumerable.Range(0, 512).Select(y => new Point(0, y)).ToArray();
            //removeShortestPathProcessor.PointsOfShortestPath = points;
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            var source = sourcePictureBox.Image;

            var result = processor.Process(new Bitmap(source));

            gradientPictureBox.Image = result;

            result = pathProcessor.Process(result);

            pixelPathPictureBox.Image = result;

            var coordinates = shortestPathFinder.FindShortestPath(result);
            shortestPathMarker.PointsOfShortestPath = coordinates;
            removeShortestPathProcessor.PointsOfShortestPath = coordinates;

            result = shortestPathMarker.Process(sourcePictureBox.Image as Bitmap);

            shortestPathPictureBox.Image = result;

            sourcePictureBox.Image = removeShortestPathProcessor.Process(result);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourcePictureBox.Image.Dispose();
            gradientPictureBox.Image.Dispose();
        }

        private void ProcessNextButton_Click(object sender, EventArgs e)
        {
            var source = sourcePictureBox.Image;

            removalPictureBox.Image = removeShortestPathProcessor.Process(preRemovalPictureBox.Image as Bitmap);
            
            var result = processor.Process(new Bitmap(source));

            result = pathProcessor.Process(result);

            var coordinates = shortestPathFinder.FindShortestPath(result);
            shortestPathMarker.PointsOfShortestPath = coordinates;
            removeShortestPathProcessor.PointsOfShortestPath = coordinates;

            preRemovalPictureBox.Image = shortestPathMarker.Process(result);

        }

        private void Shit()
        {
            var result = removeShortestPathProcessor.Process(sourcePictureBox.Image as Bitmap);
            sourcePictureBox.Image = result;
        }
    }
}
