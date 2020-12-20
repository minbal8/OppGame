using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class ButtonIterator : Iterator<Button>
    {
        List<Button> list = new List<Button>();
        int current = 0;

        public ButtonIterator(List<Button> list)
        {
            this.list = list;
        }

        public Button First()
        {
            current = 0;
            return list[0];
        }

        public bool HasNext()
        {
            return current < list.Count;
        }

        public Button Next()
        {
            return list[current++];
        }
    }
}
