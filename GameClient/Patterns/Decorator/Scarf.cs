using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Scarf : Decorator
    {
        public Scarf()
        {
            CreateImage(new Point(), new Size(), Color.Yellow);
        }

        public override void Skin()
        {
            //base.Skin();
            skin.Skin();
            addScarf();
            Console.WriteLine("Scarf");
        }

        public void addScarf()
        {

        }
    }
}
