

using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
/**
* @(#) Level.cs
*/
namespace GameClient
{
    public class Level
    {
        public List<Wall> walls = new List<Wall>();
        public int length { get; set; }
        public int width { get; set; }
        public string name { get; set; }

        public void DrawWalls(ControlCollection controls)
        {
            foreach (var item in walls)
            {
                controls.Add(item.image);
            }
        }

    }

}
