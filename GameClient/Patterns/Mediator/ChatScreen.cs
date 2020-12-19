using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTests.Patterns.Mediator;

namespace GameClient
{
    class ChatScreen : ChatMediator
    {
        private FirstChatUser chatUser1;
        private SecondChatUser chatUser2;

        public FirstChatUser ChatUser1
        {
            set { chatUser1 = value; }
        }

        public SecondChatUser ChatUser2
        {
            set { chatUser2 = value; }
        }

        public override void DissplayMessage(string message)
        {
            if (1 == GameStateSingleton.getInstance().ClientID)
            {
                chatUser2.Notify(message);
            }
            else
            {
                chatUser1.Notify(message);
            }
        }
    }
}
