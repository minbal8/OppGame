using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient;

namespace GameTests.Patterns.Mediator
{
    public abstract class ChatMediator
    {
        public abstract void DissplayMessage(string message);
    }
}
