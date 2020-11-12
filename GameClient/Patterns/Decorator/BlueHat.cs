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
            CreateImage(new Point(), new Size(75, 85), Color.Transparent);
            image.Image = Image.FromFile("Images/BlueHat.png");
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
