using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public class Button : Subject
    {
        public PictureBox image { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        ButtonAlgorithm buttonAlgorithm;

        private int State { get; set; }

        public Button(int x, int y)
        {

            CoordinateX = x;
            CoordinateY = y;
            CreateImage(new Point(x, y), new Size(30, 30));

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
            State = buttonAlgorithm.Activate();
            if (State == 0) { SetAlgorithm(new OpenActivation()); }
            if (State == 1) { SetAlgorithm(new CloseActivation()); }
            Notify();
        }

        public bool CheckCollision(Point location, Size size)
        {
            int right = location.X + size.Width, left = location.X, top = location.Y, bottom = location.Y + size.Height;
            return right > image.Left && image.Right > left &&
                 bottom > image.Top && image.Bottom > top;
        }

        public bool CheckIfIsDistance(Point reference, int distance)
        {
            return (Math.Pow(CoordinateX - reference.X, 2) + Math.Pow(CoordinateY - reference.Y, 2)) < (distance * distance);
        }

        public override int GetState()
        {
            return State;
        }
    }
}
