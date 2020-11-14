using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    class RedHat : Decorator
    {
        private PictureBox p;

        public RedHat(PictureBox player)
        {
            this.p = player;
            CreateImage(new Point(), new Size(75, 85), Color.Transparent);
            image.Image = Image.FromFile("Images/RedHat.png");
        }

        public override void Skin()
        {
            //base.Skin();
            addRedHat(this.p);
            skin.Skin();
            
            Console.WriteLine("RedHat");
        }

        public void addRedHat(PictureBox player)
        {

            player.Controls.Add(image);
        }
    }
}
