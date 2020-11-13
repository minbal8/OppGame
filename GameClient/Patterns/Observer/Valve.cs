using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public class Valve : Observer
    {
        public PictureBox image { get; set; }

        private int ObserverState { get; set; }
        private bool IsValveOpen;

        public int PlayerID { get; set; }

        private Size originalSize;

        public Valve(int x, int y)
        {
            CreateImage(new Point(x, y), new Size(20, 100));
        }

        public void SetState(bool opened)
        {            
            if (opened) Open();
            else Close();
        }

        public bool GetState()
        {
            return IsValveOpen;
        }

        public Valve(Point upperLeft, Point bottomRight)
        {
            originalSize = new Size(bottomRight.X - upperLeft.X, bottomRight.Y - upperLeft.Y);
            CreateImage(upperLeft, originalSize);
        }

        private void CreateImage(Point loc, Size size)
        {
            image = new PictureBox();
            image.Location = loc;
            image.Size = size;
            image.BackColor = Color.Red;
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
                    SetState(!IsValveOpen);
                    break;
                case 1:
                    SetState(!IsValveOpen);
                    break;
                default:
                    break;
            }

        }

        private void Open()
        {
            image.Size = originalSize;
            IsValveOpen = true;
        }

        private void Close()
        {
            image.Size = new Size(0, 0);
            IsValveOpen = false;
        }

        public bool CheckCollision(Point location, Size size)
        {
            int right = location.X + size.Width, left = location.X, top = location.Y, bottom = location.Y + size.Height;
            return right > image.Left && image.Right > left &&
                 bottom > image.Top && image.Bottom > top;
        }

        public bool CheckLeft(PictureBox player, int stepSize)
        {
            Point loc = player.Location;
            loc.X -= stepSize;
            return CheckCollision(loc, player.Size);
        }
        public bool CheckRight(PictureBox player, int stepSize)
        {
            Point loc = player.Location;
            loc.X += stepSize;
            return CheckCollision(loc, player.Size);
        }
        public bool CheckTop(PictureBox player, int stepSize)
        {
            Point loc = player.Location;
            loc.Y -= stepSize;
            return CheckCollision(loc, player.Size);
        }
        public bool CheckBottom(PictureBox player, int stepSize)
        {
            Point loc = player.Location;
            loc.Y += stepSize;
            return CheckCollision(loc, player.Size);
        }

    }
}
