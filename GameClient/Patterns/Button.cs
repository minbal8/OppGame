using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public class Button
    {
        public PictureBox image { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        ButtonAlgorithm buttonAlgorithm;

        public Button(int x, int y)
        {

            CoordinateX = x;
            CoordinateY = y;
            CreateImage(new Point(x, y), new Size(10, 10));

        }

        private void CreateImage(Point loc, Size size)
        {
            image = new PictureBox();
            image.Location = loc;
            image.Size = size;
            image.BackColor = Color.Red;
        }

        public void SetAlgorithm(ButtonAlgorithm algorithm)
        {
            buttonAlgorithm = algorithm;
        }

        public void Activate()
        {
            buttonAlgorithm.Activate();
        }

        public bool CheckIfIsDistance(Point reference, int distance)
        {
            return (Math.Pow(CoordinateX - reference.X, 2) + Math.Pow(CoordinateY - reference.Y, 2)) < (distance * distance);
        }

    }
}
