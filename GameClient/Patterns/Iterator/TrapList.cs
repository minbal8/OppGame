using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class TrapList : TrapAggregator
    {
        List<Trap> traps;

        public TrapList(List<Trap> traps)
        {
            this.traps = traps;
        }

        public override Iterator<Trap> GetIterator()
        {
            return new TrapIterator(traps);
        }
    }
}
