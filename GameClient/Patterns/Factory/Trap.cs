

using System.Drawing;
using System.Windows.Forms;
/**
* @(#) Trap.cs
*/
namespace GameClient
{

    public class Trap
    {
        public PictureBox picture;

        int coordinateX { get { return picture.Location.X; } }

        int coordinateY { get { return picture.Location.Y; } }


        public Trap(Point upperLeft, Point bottomRight)
        {
            Size size = new Size(bottomRight.X - upperLeft.X, bottomRight.Y - upperLeft.Y);
            picture = new PictureBox();
            picture.Size = size;
            picture.Location = upperLeft;
        }

    }

}
