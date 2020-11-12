using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class RedHat : Decorator
    {
        public RedHat()
        {
            CreateImage(new Point(), new Size(75, 85), Color.Transparent);
            image.Image = Image.FromFile("Images/RedHat.png");
        }

        public void Skin()
        {
            base.Skin();
            addRedHat();
            Console.WriteLine("RedHat");
        }

        public void addRedHat()
        {

        }
    }
}
