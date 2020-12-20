using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class WallIterator : Iterator<Wall>
    {
        List<Wall> list = new List<Wall>();
        int current = 0;

        public WallIterator(List<Wall> list)
        {
            this.list = list;
        }

        public Wall First()
        {
            current = 0;
            return list[0];
        }

        public bool HasNext()
        {
            return current < list.Count;
        }

        public Wall Next()
        {
            return list[current++];
        }
    }
}
