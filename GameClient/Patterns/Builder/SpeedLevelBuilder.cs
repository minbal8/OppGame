﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace GameClient
{
	class SpeedLevelBuilder : LevelBuilder
	{
		public SpeedLevelBuilder(Level level) : base(level) { }

		public override Level BuildInnerWalls()
		{
			string[] lines = File.ReadAllLines("Levels/SpeedLevel/SpeedLevel.txt");
			foreach (var item in lines)
			{
				string[] coords = item.Split(',', ' ');
				var x1 = int.Parse(coords[0]);
				var y1 = int.Parse(coords[1]);
				var x2 = int.Parse(coords[2]);
				var y2 = int.Parse(coords[3]);
				_level.AddPart(new Wall(new Point(x1, y1), new Point(x2, y2)));
			}

			return _level;
		}

		public override Level BuildButtonsAndValves()
		{
			Console.WriteLine("Building buttons and valves ... ");

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
            Factory trapFactory = new TrapFactory();

			string[] lines = File.ReadAllLines("Levels/SpeedLevel/Traps.txt");
			foreach (var item in lines)
			{
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

			return _level;
		}
	}
}
