using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTests.Patterns.Mediator;

namespace GameClient
{
    public class ChatUser
    {
        protected ChatMediator mediator;

        public ChatUser(ChatMediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
