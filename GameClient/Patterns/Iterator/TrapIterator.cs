using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class TrapIterator : Iterator<Trap>
    {
        List<Trap> list = new List<Trap>();
        int current = 0;

        public TrapIterator(List<Trap> list)
        {
            this.list = list;
        }

        public Trap First()
        {
            current = 0;
            return list[0];
        }

        public bool HasNext()
        {
            return current < list.Count;
        }

        public Trap Next()
        {
            return list[current++];
        }
    }
}
