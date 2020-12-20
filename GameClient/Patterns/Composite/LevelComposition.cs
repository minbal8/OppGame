using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public abstract class LevelComposition
    {

        protected string name;

        protected LevelComposition(string name)
        {
            this.name = name;
        }

        public abstract void Add(LevelComposition c);
        public abstract void Remove(LevelComposition c);
        public abstract void DisplayTree(int depth);
    }
}
