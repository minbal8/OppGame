using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Patterns.Interpreter
{
    abstract class SentenceExpression
    {
        public abstract void Interpret(Context context);
    }
}
