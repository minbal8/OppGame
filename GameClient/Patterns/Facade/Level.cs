

using System;
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
        protected List<ValveSync> valveSync = new List<ValveSync>();

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
        }

        public void UpdateValves(int id)
        {
            var tempStates = GameStateSingleton.getInstance().SyncedValvesStates;
            if (tempStates != null)
            {
                valveSync = tempStates;
            }

            for (int i = 0; i < valves.Count; i++)
            {
                if (valves[i].PlayerID == id)
                {
                    valveSync[i].State = valves[i].GetState();
                }
                valves[i].SetState(valveSync[i].State);
            }

            GameStateSingleton.getInstance().LocalValvesStates = valveSync;
        }

        #region Collisions
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
        #endregion

        #region AddLevelPartsMethods

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
            var temp = new ValveSync();
            temp.State = valve.GetState();
            temp.PlayerID = valve.PlayerID;
            valveSync.Add(temp);
            valves.Add(valve);
        }

        public void AddPart(Button button)
        {
            buttons.Add(button);
        }
        #endregion
    }

}
