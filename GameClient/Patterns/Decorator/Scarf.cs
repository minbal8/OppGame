using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    class Scarf : Decorator
    {
        private PictureBox p;

        public Scarf(PictureBox player)
        {
            this.p = player;
            CreateImage(new Point(), new Size(75, 50), Color.Transparent);
            image.Image = Image.FromFile("Images/RedScarf.png");
        }

        public override void Skin()
        {
            //base.Skin();
            addScarf(this.p);
            skin.Skin();
            
            Console.WriteLine("Scarf");
        }

        public void addScarf(PictureBox player)
        {
            player.Controls.Add(image);
        }
    }
}
