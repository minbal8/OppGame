using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    class PlayerAnimator
    {
        private Image RunningR, RunningL, StandR, StandL;
        private Image RunningR2, RunningL2, StandR2, StandL2;



        private PictureBox player1, player2;
        private Point lastPos1 = new Point(), lastPos2 = new Point(), current1, current2;
        private bool LookingRight1, LookingRight2;

        // 0 - runR
        // 1 - runL
        // 2 - standR
        // 3 - standL

        private int animation1, lastAnimanion1, animation2, lastAnimanion2;



        public PlayerAnimator(PictureBox p1, PictureBox p2)
        {
            RunningR = Image.FromFile("Images/RunningR.gif");
            RunningL = Image.FromFile("Images/RunningL.gif");
            StandR = Image.FromFile("Images/StandR.gif");
            StandL = Image.FromFile("Images/StandL.gif");

            RunningR2 = Image.FromFile("Images/RunningR2.gif");
            RunningL2 = Image.FromFile("Images/RunningL2.gif");
            StandR2 = Image.FromFile("Images/StandR2.gif");
            StandL2 = Image.FromFile("Images/StandL2.gif");

            player1 = p1;
            player2 = p2;

        }

        public void Update()
        {
            var p1 = GameStateSingleton.getInstance().Player1;
            var p2 = GameStateSingleton.getInstance().Player2;
            current1 = new Point(p1.PosX, p1.PosY);
            current2 = new Point(p2.PosX, p2.PosY);

            int dx1 = lastPos1.X - current1.X, dy1 = lastPos1.Y - current1.Y;
            int dx2 = lastPos2.X - current2.X, dy2 = lastPos2.Y - current2.Y;

            // player1
            if (dx1 == 0 && dy1 == 0)
                if(LookingRight1) animation1 = 3;
                else animation1 = 2;
            if (dy1 != 0 && LookingRight1) animation1 = 1;
            if (dy1 != 0 && !LookingRight1) animation1 = 0;
            if (dx1 > 0) { animation1 = 1; LookingRight1 = true; }
            if (dx1 < 0) { animation1 = 0; LookingRight1 = false; }

            if (animation1 != lastAnimanion1)
            {
                if (animation1 == 0) player1.Image = RunningR;
                if (animation1 == 1) player1.Image = RunningL;
                if (animation1 == 2) player1.Image = StandR;
                if (animation1 == 3) player1.Image = StandL;
            }

            // player2
            if (dx2 == 0 && dy2 == 0)
                if (LookingRight2) animation2 = 3;
                else animation2 = 2;
            if (dy2 != 0 && LookingRight2) animation2 = 1;
            if (dy2 != 0 && !LookingRight2) animation2 = 0;
            if (dx2 > 0) { animation2 = 1; LookingRight2 = true; }
            if (dx2 < 0) { animation2 = 0; LookingRight2 = false; }

            if (animation2 != lastAnimanion2)
            {
                if (animation2 == 0) player2.Image = RunningR2;
                if (animation2 == 1) player2.Image = RunningL2;
                if (animation2 == 2) player2.Image = StandR2;
                if (animation2 == 3) player2.Image = StandL2;
            }

            //***********************************************

            lastAnimanion1 = animation1;
            lastAnimanion2 = animation2;
            lastPos1 = current1;
            lastPos2 = current2;

        }

    }
}
