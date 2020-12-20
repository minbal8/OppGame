using System.Drawing;
using System.IO;


namespace GameClient
{
    public class LogicLevel : Level
    {
        public LogicLevel()
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
