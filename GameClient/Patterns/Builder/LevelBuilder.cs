using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public abstract class LevelBuilder
    {

        protected Level _level;

        public LevelBuilder(Level level)
        {
            _level = level;
        }

        public void BuildOuterWalls()
        {
            _level.AddPart(new Wall(new Point(0, 0), new Size(1280, 5)));
            _level.AddPart(new Wall(new Point(0, 720), new Size(1280, 5)));
            _level.AddPart(new Wall(new Point(1280, 0), new Size(5, 720)));
            _level.AddPart(new Wall(new Point(0, 0), new Size(5, 720)));
        }

        public abstract void BuildInnerWalls();
        public abstract void BuildTraps();
        public abstract void BuildButtonsAndValves();
        public abstract void BuildStartAndFinishAreas();

    }
}
