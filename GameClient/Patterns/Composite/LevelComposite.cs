using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class LevelComposite : LevelComposition
    {

        private readonly List<LevelComposition> _children = new List<LevelComposition>();

        public LevelComposite(string name) : base(name)
        {

        }

        public override void Add(LevelComposition c)
        {
            _children.Add(c);
        }

        public override void Remove(LevelComposition c)
        {
            _children.Remove(c);
        }

        public override void GetChild(int depth)
        {
            // Recursively display child nodes
            foreach (LevelComposition component in _children)
            {
                component.GetChild(depth + 2);
            }
        }
    }
}
