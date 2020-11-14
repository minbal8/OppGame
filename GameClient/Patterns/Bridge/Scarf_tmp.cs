using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    class Scarf_tmp : Wearable
    {
        private PictureBox p;

        public Scarf_tmp(PictureBox player)
        {
            this.p = player;
            CreateImage(new Point(0,50), new Size(75, 20), Color.Transparent);

        }

        public override string Draw()
        {

            image.Image = Image.FromFile("Images/" + base.Draw() + ScarfItem() + ".png");
            addScarf(p);

            //base.Draw();
            //ScarfItem();
            return "a";
        }

        public string ScarfItem()
        {
            return "Scarf";
        }

        public void addScarf(PictureBox player)
        {

            player.Controls.Add(image);
        }
    }
}
