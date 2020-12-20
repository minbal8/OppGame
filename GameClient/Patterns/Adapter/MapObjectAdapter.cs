using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace GameClient
{
    public class MapObjectAdapter
    {
        public List<Wall> walls = new List<Wall>();
        public List<Valve> valves = new List<Valve>();
        public List<Button> buttons = new List<Button>();
        public List<Trap> traps = new List<Trap>();
        


        public void DrawLevel(ControlCollection controls)
        {

            foreach (var item in walls)
            {
                controls.Add(item.image);
            }

            foreach (var item in traps)
            {
                controls.Add(item.picture);
            }

            foreach (var item in valves)
            {
                controls.Add(item.image);
            }

            foreach (var item in buttons)
            {
                controls.Add(item.image);
            }

        }
    }
}
