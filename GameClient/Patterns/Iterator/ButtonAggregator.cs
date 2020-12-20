using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    abstract class ButtonAgregator
    {
        public abstract Iterator<Button> GetIterator();
    }
}
