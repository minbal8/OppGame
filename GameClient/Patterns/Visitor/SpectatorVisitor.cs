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
            Console.WriteLine("Spectator visitor: " + level.ConcreteSpeedLevelMethod());
        }

        public override void Visit(LogicLevel level)
        {
            Console.WriteLine("Spectator visitor: " + level.ConcreteLogicLevelMethod());
        }
    }
}
