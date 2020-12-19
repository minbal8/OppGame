using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public abstract class PlayerState
    {
        public string PlayerID { get; set; }
        public PlayerState(string id)
        {
            PlayerID = id;
        }
        public Image stateImage { get; set; }
        public abstract PlayerState ChangeState(int animation);

    }
}
