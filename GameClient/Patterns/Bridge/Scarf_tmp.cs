using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Scarf_tmp : Wearable
    {
        public override void Draw()
        {
            base.Draw();
            ScarfItem();
        }

        public void ScarfItem()
        {
            Console.WriteLine("set scarf");
        }
    }
}
