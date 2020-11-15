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
        protected List<Wall> walls = new List<Wall>();
        protected List<Valve> valves = new List<Valve>();
        protected List<Button> buttons = new List<Button>();
        protected List<Trap> traps = new List<Trap>();

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
