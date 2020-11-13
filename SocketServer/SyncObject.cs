using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SocketServer
{
    public class SyncObject
    {
        public int levelID { get; set; }
        public int ClientID { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public List<ValveSync> valves { get; set; }

        public SyncObject()
        {
            Player1 = new Player();
            Player1.PosX = 22;
            Player1.PosY = 5;
            Player2 = new Player();
            Player2.PosX = 1188;
            Player2.PosY = 5;
        }
    }

    public class ValveSync
    {
        public int PlayerID { get; set; }
        public bool State { get; set; }
    }
}

