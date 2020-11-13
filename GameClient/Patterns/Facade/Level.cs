

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
/**
* @(#) Level.cs
*/
namespace GameClient
{
    public class Level
    {
        protected List<Wall> walls = new List<Wall>();
        protected List<Valve> valves = new List<Valve>();
        protected List<Button> buttons = new List<Button>();
        protected List<Trap> traps = new List<Trap>();

        public int length { get; set; }
        public int width { get; set; }

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

            //TestCase(controls);
        }

        private void TestCase(ControlCollection controls)
        {
            Button but = new Button(100, 100);
            but.SetAlgorithm(new OpenActivation());

            Valve v = new Valve(200, 200);
            but.Attach(v);


            controls.Add(but.image);
            controls.Add(v.image);
            buttons.Add(but);
        }

        public int CheckHorizontalCollisions(int dx, PictureBox player, int stepSize)
        {
            foreach (var item in walls)
            {
                if (dx < 0 && item.CheckLeft(player, stepSize)) { dx = 0; }
                if (dx > 0 && item.CheckRight(player, stepSize)) { dx = 0; }
            }

            foreach (var item in valves)
            {
                if (dx < 0 && item.CheckLeft(player, stepSize)) { dx = 0; }
                if (dx > 0 && item.CheckRight(player, stepSize)) { dx = 0; }
            }
            return dx;
        }

        public int CheckVerticalCollisions(int dy, PictureBox player, int stepSize)
        {
            foreach (var item in walls)
            {
                if (dy < 0 && item.CheckTop(player, stepSize)) { dy = 0; }
                if (dy > 0 && item.CheckBottom(player, stepSize)) { dy = 0; }
            }

            foreach (var item in valves)
            {
                if (dy < 0 && item.CheckTop(player, stepSize)) { dy = 0; }
                if (dy > 0 && item.CheckBottom(player, stepSize)) { dy = 0; }
            }

            return dy;
        }

        public void PressButton(PictureBox player)
        {
            foreach (var button in buttons)
            {
                if (button.CheckCollision(player.Location, player.Size))
                {
                    button.Activate();
                }
            }
        }

        public void AddPart(Wall wall)
        {
            walls.Add(wall);
        }

        public void AddPart(Trap trap)
        {
            traps.Add(trap);
        }

        public void AddPart(Valve valve)
        {
            valves.Add(valve);
        }

        public void AddPart(Button button)
        {
            buttons.Add(button);
        }

    }

}