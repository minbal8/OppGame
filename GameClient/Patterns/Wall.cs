using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public class Wall
    {
        public PictureBox image { get; set; }

        public Wall(Point location, Size size)
        {
            image = new PictureBox();
            image.Location = location;
            image.Size = size;
            image.BackColor = Color.Black;
        }

        public bool CheckCollision(PictureBox player)
        {
            return CheckCollision(player.Location, player.Size);
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
