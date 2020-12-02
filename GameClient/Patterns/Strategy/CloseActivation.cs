using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public class CloseActivation : ButtonAlgorithm
    {
        public override int Activate()
        {
            Console.WriteLine("Closed");
            return 0;
        }
    }
}
