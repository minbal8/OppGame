using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class ReturnToLevelHandler : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request == 0)
            {
                Console.WriteLine("Restart Level");
            }
            else if (request != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
