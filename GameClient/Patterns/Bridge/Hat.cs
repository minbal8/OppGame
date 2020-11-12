using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Hat : Wearable
    {

        public override void Draw()
        {
            base.Draw();
            HatItem();
        }

        public void HatItem()
        {
            Console.WriteLine("set hat");
        }
    }
}
