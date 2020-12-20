using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTests.Patterns.Mediator;

namespace GameClient
{
    class SecondChatUser : ChatUser
    {
        public SecondChatUser(ChatMediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.DissplayMessage(message);
        }

        public void Notify(string message)
        {
            GameStateSingleton.getInstance().Player1.Message = "Player1 sent message: " + message;
        }
    }
}
