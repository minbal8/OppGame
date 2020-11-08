using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Scarf : Decorator
    {
        public void Skin()
        {
            base.Skin();
            addScarf();
            Console.WriteLine("Scarf");
        }

        public void addScarf()
        {

        }
    }
}
