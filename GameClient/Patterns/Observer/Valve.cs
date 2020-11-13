using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public class Valve : Observer
    {
        public PictureBox image { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        private int ObserverState { get; set; }
        private bool Opened;

        public Valve(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
            CreateImage(new Point(x, y), new Size(20, 100));
        }

        private void CreateImage(Point loc, Size size)
        {
            image = new PictureBox();
            image.Location = loc;
            image.Size = size;
            image.BackColor = Color.Black;
        }

        public override void Update()
        {
            ObserverState = _subject.GetState();
            SetValveImage();
        }

        private void SetValveImage()
        {
            switch (ObserverState)
            {
                case 0:
                    Close();
                    break;
                case 1:
                    Open();
                    break;
                default:
                    break;
            }

        }

        private void Open()
        {
            image.Size = new Size(200, 200);
        }

        private void Close()
        {
            image.Size = new Size(0, 0);
        }
    }
}
