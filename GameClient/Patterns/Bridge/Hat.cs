using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public class Hat : Wearable, HatPrototype
    {
        private PictureBox p;

        public Hat(PictureBox player)
        {
            this.p = player;
            CreateImage(new Point(0,7), new Size(75, 85), Color.Transparent);
            
        }

        public override string Draw()
        {
            image.Image = Image.FromFile("Images/"+ base.Draw() + HatItem() + ".png");
            addHat(p);

            //base.Draw();

            //HatItem();
            return "";
        }

        public string HatItem()
        {
            return "Hat";
            //Console.WriteLine("set hat");
        }

        public void addHat(PictureBox player)
        {

            player.Controls.Add(image);
        }

        public string GetPlayerPosition()
        {
            return p.Location.ToString();
        }

        public HatPrototype Clone()
        {
            return this.MemberwiseClone() as HatPrototype;
        }
    }
}
