using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    class BlueHat : Decorator
    {
        private PictureBox p;

        public BlueHat(PictureBox player)
        {
            this.p = player;
            CreateImage(new Point(0,20), new Size(75, 85), Color.Transparent);
            image.Image = Image.FromFile("Images/BlueHat.png");
        }

        public override void Skin()
        {
            //base.Skin();
            addBlueHat(this.p);
            skin.Skin();

            Console.WriteLine("BlueHat");
        }

        public void addBlueHat(PictureBox player)
        {
            player.Controls.Add(image);
            //Console.WriteLine("added BlueHat");
        }
    }
}
