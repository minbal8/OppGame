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
            CreateImage(new Point(0,0), new Size(10, 50), Color.Red);
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
