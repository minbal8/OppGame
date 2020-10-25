using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public class LogicLevelBuilder : LevelBuilder
    {
        public LogicLevelBuilder(Level level) : base(level) { }

        public override void BuildButtonsAndValves()
        {
            Console.WriteLine("Building buttons and valves ... ");
        }

        public override void BuildInnerWalls()
        {
            string[] lines = File.ReadAllLines("Levels/LogicLevel.txt");
            foreach (var item in lines)
            {
                string[] coords = item.Split(',');
                var x1 = int.Parse(coords[0]);
                var y1 = int.Parse(coords[1]);
                var x2 = int.Parse(coords[2]);
                var y2 = int.Parse(coords[3]);
                _level.AddWall(new Wall(new Point(x1, y1), new Point(x2, y2)));
            }
        }

        public override void BuildStartAndFinish()
        {
            Console.WriteLine("Building start and finish areas ... ");
        }

        public override void BuildTraps()
        {
            Console.WriteLine("Building traps ... ");
        }
    }
}
