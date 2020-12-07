

using System.Drawing;
using System.Windows.Forms;
/**
* @(#) Trap.cs
*/
namespace GameClient
{

    public abstract class Trap
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

        public void SetImage(Image image)
        {
            picture.Image = image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void TrapTemplate(PictureBox player)
        {
            UpdateTrapState();
            if (CheckCollision(player.Location, player.Size))
            {
                DealDamage();
            }
        }

        protected abstract void UpdateTrapState();
        protected abstract void DealDamage();


        private bool CheckCollision(Point location, Size size)
        {
            int right = location.X + size.Width, left = location.X, top = location.Y, bottom = location.Y + size.Height;
            return right > picture.Left && picture.Right > left &&
                 bottom > picture.Top && picture.Bottom > top;
        }
    }

}
