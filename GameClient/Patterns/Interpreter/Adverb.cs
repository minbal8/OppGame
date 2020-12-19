using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Patterns.Interpreter
{
    class Adverb : SentenceExpression
    {
        public override void Interpret(Context context)
        {
            char expression = context.Input[1];

            switch (expression)
            {
                case 'z':
                    context.Output += " left";
                    break;
                case 'x':
                    context.Output += " right";
                    break;
                case 'c':
                    context.Output += " up";
                    break;
                case 'v':
                    context.Output += " down";
                    break;
                default:
                    context.Output += " Unknown expression";
                    break;
            }
        }
    }
}
