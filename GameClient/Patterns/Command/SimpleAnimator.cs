using System.Drawing;

namespace GameClient
{
    public class SimpleAnimator
    {
        private Image RunningR, RunningL, StandR, StandL;
        public SimpleAnimator(string id)
        {
            RunningR = Image.FromFile("Images/RunningR" + id + ".gif");
            RunningL = Image.FromFile("Images/RunningL" + id + ".gif");
            StandR = Image.FromFile("Images/StandR" + id + ".gif");
            StandL = Image.FromFile("Images/StandL" + id + ".gif");
        }

        public Image RunLeft()
        {
            return RunningL;
        }
        public Image RunRight()
        {
            return RunningR;
        }

        public Image StandLeft()
        {
            return StandL;
        }
        public Image StandRight()
        {
            return StandR;
        }


    }
}
