using System.Drawing;
using System.IO;


namespace GameClient
{
    public class LogicLevel : Level
    {
        public LogicLevel(string name)
        {
            string[] lines = File.ReadAllLines(name);
            foreach (var item in lines)
            {
                string[] coords = item.Split(',', ' ');

                var x1 = int.Parse(coords[0]);
                var y1 = int.Parse(coords[1]);
                var x2 = int.Parse(coords[3]);
                var y2 = int.Parse(coords[4]);

                walls.Add(new Wall(new Point(x1, y1), new Point(x2, y2)));
            }
        }
    }
}
