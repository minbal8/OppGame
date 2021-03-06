

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
    public class Level : LevelComposition
    {
        protected List<ValveSync> valveSync = new List<ValveSync>();
        MapObjectAdapter map = new MapObjectAdapter();

        public int length { get; set; }
        public int width { get; set; }
        private string state;

        public Level(string name) : base(name)
        {

        }

        public void UpdateValves(int id)
        {
            var tempStates = GameStateSingleton.getInstance().SyncedValvesStates;
            if (tempStates != null)
            {
                valveSync = tempStates;
            }

            for (int i = 0; i < map.valves.Count; i++)
            {
                if (map.valves[i].PlayerID == id)
                {
                    valveSync[i].State = map.valves[i].GetState();
                }
                map.valves[i].SetState(valveSync[i].State);
            }

            GameStateSingleton.getInstance().LocalValvesStates = valveSync;
        }

        public void DrawLevel(ControlCollection controls)
        {
            map.DrawLevel(controls);
        }

        public virtual void Accept(Visitor visitor)
        {

        }

        public string State
        {
            get { return state; }
            set

            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(state));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }

        #region Collisions
        public int CheckHorizontalCollisions(int dx, PictureBox player, int stepSize)
        {
            foreach (var item in map.walls)
            {
                if (dx < 0 && item.CheckLeft(player, stepSize)) { dx = 0; }
                if (dx > 0 && item.CheckRight(player, stepSize)) { dx = 0; }
            }

            foreach (var item in map.valves)
            {
                if (dx < 0 && item.CheckLeft(player, stepSize)) { dx = 0; }
                if (dx > 0 && item.CheckRight(player, stepSize)) { dx = 0; }
            }
            return dx;
        }

        public int CheckVerticalCollisions(int dy, PictureBox player, int stepSize)
        {
            foreach (var item in map.walls)
            {
                if (dy < 0 && item.CheckTop(player, stepSize)) { dy = 0; }
                if (dy > 0 && item.CheckBottom(player, stepSize)) { dy = 0; }
            }

            foreach (var item in map.valves)
            {
                if (dy < 0 && item.CheckTop(player, stepSize)) { dy = 0; }
                if (dy > 0 && item.CheckBottom(player, stepSize)) { dy = 0; }
            }

            return dy;
        }

        public void CheckTraps(PictureBox player)
        {
            foreach (var item in map.traps)
            {
                item.TrapTemplate(player);
            }
        }

        public void PressButton(PictureBox player)
        {
            foreach (var button in map.buttons)
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
            map.walls.Add(wall);
        }

        public void AddPart(Trap trap)
        {
            map.traps.Add(trap);
        }

        public void AddPart(Valve valve)
        {
            var temp = new ValveSync();
            temp.State = valve.GetState();
            temp.PlayerID = valve.PlayerID;
            valveSync.Add(temp);
            map.valves.Add(valve);
        }

        public void AddPart(Button button)
        {
            map.buttons.Add(button);
        }


        #endregion

        #region LevelAsLeaf

        public override void Add(LevelComposition c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(LevelComposition c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void DisplayTree(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

        #endregion

    }

}
