﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override Level BuildButtonsAndValves()
        {
            Console.WriteLine("Building buttons and valves ... ");
            string[] lines = File.ReadAllLines("Levels/LogicLevel/ButtonsAndValves.txt");
            Button button = null;
            foreach (var item in lines)
            {
                string[] coords = item.Split(',');

                if (coords.Length == 2)
                {
                    var x1 = int.Parse(coords[0]);
                    var y1 = int.Parse(coords[1]);
                    button = new Button(x1, y1);
                    button.SetAlgorithm(new OpenActivation());
                    _level.AddPart(button);
                }
                else
                {

                    var x1 = int.Parse(coords[0]);
                    var y1 = int.Parse(coords[1]);
                    var x2 = int.Parse(coords[2]);
                    var y2 = int.Parse(coords[3]);

                    var state = int.Parse(coords[4]) == 1;
                    var playerID = int.Parse(coords[5]);

                    if (button != null)
                    {
                        Valve valve = new Valve(new Point(x1, y1), new Point(x2, y2));
                        valve.SetState(state);
                        valve.PlayerID = playerID;
                        button.Attach(valve);
                        _level.AddPart(valve);
                    }
                }
            }
            return _level;
        }

        public override Level BuildInnerWalls()
        {
            Console.WriteLine("Building inner walls ...");
            string[] lines = File.ReadAllLines("Levels/LogicLevel/LogicLevel.txt");
            foreach (var item in lines)
            {
                string[] coords = item.Split(',');
                var x1 = int.Parse(coords[0]);
                var y1 = int.Parse(coords[1]);
                var x2 = int.Parse(coords[2]);
                var y2 = int.Parse(coords[3]);
                _level.AddPart(new Wall(new Point(x1, y1), new Point(x2, y2)));
            }
            return _level;
        }

        public override Level BuildStartAndFinishAreas()
        {
            Console.WriteLine("Building start and finish areas ... ");
            return _level;
        }

        public override Level BuildTraps()
        {
            Console.WriteLine("Building traps ... ");

            Stopwatch sw = new Stopwatch();
            Process proc = Process.GetCurrentProcess();
            sw.Start();

            Factory trapFactory = new TrapFactory();
            int trapCount = 0;
            string[] lines = File.ReadAllLines("Levels/LogicLevel/Traps.txt");
            foreach (var item in lines)
            {
                trapCount++;
                string[] coords = item.Split(',');
                var type = int.Parse(coords[0]);
                var x1 = int.Parse(coords[1]);
                var y1 = int.Parse(coords[2]);
                var x2 = int.Parse(coords[3]);
                var y2 = int.Parse(coords[4]);

                Trap temp = trapFactory.CreateTrap(type,
                    new Point(x1, y1),
                    new Point(x2, y2));

                _level.AddPart(temp);

            }

            sw.Stop();
            Console.WriteLine("Number of traps created: " + trapCount);
            Console.WriteLine("Time elapsed: " + sw.Elapsed + " ms");
            Console.WriteLine("Memory used: " + proc.PrivateMemorySize64 + " ");

            return _level;
        }
    }
}
