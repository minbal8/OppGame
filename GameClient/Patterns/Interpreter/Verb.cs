using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.Patterns.Interpreter;

namespace GameClient
{
    class Verb : SentenceExpression
    {
        public override void Interpret(Context context)
        {
            char expression = context.Input[0];

            switch (expression)
            {
                case '1':
                    context.Output += "go";
                    break;
                case '2':
                    context.Output += "run";
                    break;
                case '3':
                    context.Output += "stay";
                    break;
                case '4':
                    context.Output += "stand";
                    break;
                default:
                    context.Output += "Unknown expression";
                    break;
            }
        }
    }
}
