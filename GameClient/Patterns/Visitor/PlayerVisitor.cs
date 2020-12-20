using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class PlayerVisitor : Visitor
    {
        public override void Visit(SpeedLevel level)
        {
            Console.WriteLine("Player visitor: " + level.ConcreteSpeedLevelMethod());
        }

        public override void Visit(LogicLevel level)
        {
            Console.WriteLine("Player visitor: " + level.ConcreteLogicLevelMethod());
        }
    }
}
