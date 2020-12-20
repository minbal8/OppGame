using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public abstract class Visitor
    {
        public abstract void Visit(SpeedLevel level);
        public abstract void Visit(LogicLevel level);

    }
}
