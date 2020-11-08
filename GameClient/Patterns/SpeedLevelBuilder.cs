﻿using System;
using System.Drawing;
using System.IO;

namespace GameClient
{
    class SpeedLevelBuilder : LevelBuilder
    {
        public SpeedLevelBuilder(Level level) : base(level) { }        

        public override void BuildInnerWalls()
        {
            string[] lines = File.ReadAllLines("Levels/SpeedLevel.txt");
            foreach (var item in lines)
            {
                string[] coords = item.Split(',', ' ');
                var x1 = int.Parse(coords[0]);
                var y1 = int.Parse(coords[1]);
                var x2 = int.Parse(coords[2]);
                var y2 = int.Parse(coords[3]);
                _level.AddWall(new Wall(new Point(x1, y1), new Point(x2, y2)));
            }
        }

        public override void BuildButtonsAndValves()
        {
            Console.WriteLine("Building buttons and valves ... ");
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