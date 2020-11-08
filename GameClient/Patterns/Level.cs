

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
        public List<Wall> walls = new List<Wall>();
        public List<Valve> valves = new List<Valve>();
        public List<Button> buttons = new List<Button>();
        public List<Trap> traps = new List<Trap>();


        public int length { get; set; }
        public int width { get; set; }

        public void DrawWalls(ControlCollection controls)
        {
            foreach (var item in walls)
            {
                controls.Add(item.image);
            }

            TestCase(controls);
        }

        private void TestCase(ControlCollection controls)
        {
            Button but = new Button(100, 100);
            but.SetAlgorithm(new OpenActivation());

            Valve v = new Valve(200,200);
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
            return dx;
        }

        public int CheckVerticalCollisions(int dy, PictureBox player, int stepSize)
        {
            foreach (var item in walls)
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

        public void AddWall(Wall wall)
        {
            walls.Add(wall);
        }

        public void AddPart()
        {

        }

    }

}
