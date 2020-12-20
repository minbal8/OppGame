using System.Drawing;
using System.IO;


namespace GameClient
{
    public class LogicLevel : Level
    {
        public LogicLevel(string name) : base(name)
        {
            
        }

        public LogicLevel() : this("Logic Level")
        {

        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public string ConcreteLogicLevelMethod()
        {
            return "Returned string from Logic level";
        }

    }
}
