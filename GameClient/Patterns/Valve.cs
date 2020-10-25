using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public class Valve
    {
        public PictureBox image { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

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
            image.BackColor = Color.Red;
        }

        public void Open()
        {

        }

        public void Close()
        {

        }
    }
}
