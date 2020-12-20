using System.Drawing;

namespace GameClient
{
    class StandRightState : PlayerState
    {
        public StandRightState(string PlayerID) : base(PlayerID)
        {
            stateImage = Image.FromFile("Images/StandR" + PlayerID + ".gif");
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
