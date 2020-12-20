using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class SpectatorVisitor : Visitor
    {
        public override void Visit(SpeedLevel level)
        {
            throw new NotImplementedException();
        }

        public override void Visit(LogicLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
