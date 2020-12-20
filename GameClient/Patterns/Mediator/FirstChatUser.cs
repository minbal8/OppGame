using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTests.Patterns.Mediator;

namespace GameClient
{
    class FirstChatUser : ChatUser
    {
        public FirstChatUser(ChatMediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.DissplayMessage(message);
        }

        public void Notify(string message)
        {
            GameStateSingleton.getInstance().Player2.Message = message;
        }
    }
}
