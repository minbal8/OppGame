using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler succesor)
        {
            this.successor = succesor;
        }

        public abstract void HandleRequest(int request);
    }
}
