using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameClient
{
    public class GameStateSingleton
    {
        private static GameStateSingleton instance = new GameStateSingleton();
        private static readonly object padlock = new object();

        public int ClientID { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int LevelID { get; set; }
        public List<ValveSync> LocalValvesStates { get; set; }
        public List<ValveSync> SyncedValvesStates { get; set; }

        GameStateSingleton()
        {
            Player1 = new Player();
            Player2 = new Player();
        }

        public void DealDamageToPlayer(int dmg)
        {
            System.Console.Write(Player1.Health + " ");
            if (ClientID == 1)
            {
                Player1.TakeDamage(dmg);
            }
            if (ClientID == 2)
            {
                Player2.TakeDamage(dmg);
            }
            System.Console.Write(Player1.Health);
            System.Console.WriteLine();

        }

        public static GameStateSingleton getInstance()
        {
            lock (padlock)
            {
                return instance;
            }
        }

    }
}
