using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class RedHat : Decorator
    {
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
