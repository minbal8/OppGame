using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    interface IClient
    {
        bool Connect();
        bool Send(string message);
        string WaitForReply();
        bool Close();
    }
}
