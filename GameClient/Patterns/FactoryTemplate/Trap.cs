

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


        protected float deltaTime = Form1.DeltaTime;
        protected bool isOnTrap = false;
        protected float timeOnTrap = 0;
        protected bool isDamaging = false;

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

            if (CheckCollision(player.Location, player.Size))
            { CalculateTime(); }
            else { timeOnTrap = 0; }
            UpdateTrapState();
            if (isDamaging)
            {
                DealDamage();
            }
        }

        protected abstract void UpdateTrapState();
        protected abstract void DealDamage();
        protected virtual void CalculateTime()
        {            
            timeOnTrap += deltaTime;
        }


        private bool CheckCollision(Point location, Size size)
        {
            int right = location.X + size.Width, left = location.X, top = location.Y, bottom = location.Y + size.Height;
            return right > picture.Left && picture.Right > left &&
                 bottom > picture.Top && picture.Bottom > top;
        }
    }

}
