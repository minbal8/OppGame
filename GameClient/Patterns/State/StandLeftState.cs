using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class StandLeftState : PlayerState
    {
        public StandLeftState(string PlayerID) : base(PlayerID)
        {
            stateImage = Image.FromFile("Images/StandL" + PlayerID + ".gif");
        }

        public override PlayerState ChangeState(int i)
        {
            switch (i)
            {
                case 0:
                    return new RunningRightState(PlayerID);
                case 1:
                    return new RunningLeftState(PlayerID);
                case 2:
                    return new StandRightState(PlayerID);
                case 3:
                    return new StandLeftState(PlayerID);
                default:
                    return new StandRightState(PlayerID);
            }

        }
    }
}
