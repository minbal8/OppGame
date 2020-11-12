using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class BlueHat : Decorator
    {
        public BlueHat()
        {
            CreateImage(new Point(), new Size(), Color.Blue);
        }

        public void Skin()
        {
            base.Skin();
            addBlueHat();
            Console.WriteLine("BlueHat");
        }

        public void addBlueHat()
        {
            Console.WriteLine("added BlueHat");
        }
    }
}
