using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    class Decorator : Skin
    {
        protected Skin skin;

        public PictureBox image;

        public void setSkin(Skin skin)
        {
            this.skin = skin;
        }

        protected void CreateImage(Point loc, Size size, Color color)
        {
            image = new PictureBox();
            image.Location = loc;
            image.Size = size;
            image.BackColor = color;
            image.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Skin()
        {
            if (skin != null)
            {
                skin.Skin();
            }
        }
    }
}
