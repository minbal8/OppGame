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

        private PictureBox player1PictureBox, player2PictureBox;
        private Player player1, player2;
        private Point lastPos1 = new Point(), lastPos2 = new Point(), current1, current2;

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

            player1PictureBox = p1;
            player2PictureBox = p2;
        }


        int dx, dy, animation, clientID;
        bool LookingRight;


        private void DecideAnimation()
        {
            clientID = GameStateSingleton.getInstance().ClientID;
            if (clientID == 1)
            {
                dx = lastPos1.X - current1.X;
                dy = lastPos1.Y - current1.Y;
            }
            if (clientID == 2)
            {
                dx = lastPos2.X - current2.X;
                dy = lastPos2.Y - current2.Y;
            }

            if (dx == 0 && dy == 0)
                if (LookingRight) animation = 3;
                else animation = 2;
            if (dy != 0 && LookingRight) animation = 1;
            if (dy != 0 && !LookingRight) animation = 0;
            if (dx > 0) { animation = 1; LookingRight = true; }
            if (dx < 0) { animation = 0; LookingRight = false; }

            if (clientID == 1)
            {
                GameStateSingleton.getInstance().Player1.Animation = animation;
            }
            if (clientID == 2)
            {
                GameStateSingleton.getInstance().Player2.Animation = animation;
            }

        }

        public void Update()
        {

            player1 = GameStateSingleton.getInstance().Player1;
            player2 = GameStateSingleton.getInstance().Player2;

            current1 = new Point(player1.PosX, player1.PosY);
            current2 = new Point(player2.PosX, player2.PosY);

            DecideAnimation();

            animation1 = player1.Animation;
            animation2 = player2.Animation;

            if (animation1 != lastAnimanion1)
            {
                if (animation1 == 0) player1PictureBox.Image = RunningR;
                if (animation1 == 1) player1PictureBox.Image = RunningL;
                if (animation1 == 2) player1PictureBox.Image = StandR;
                if (animation1 == 3) player1PictureBox.Image = StandL;
            }

            if (animation2 != lastAnimanion2)
            {
                if (animation2 == 0) player2PictureBox.Image = RunningR2;
                if (animation2 == 1) player2PictureBox.Image = RunningL2;
                if (animation2 == 2) player2PictureBox.Image = StandR2;
                if (animation2 == 3) player2PictureBox.Image = StandL2;
            }

            //***********************************************

            lastAnimanion1 = animation1;
            lastAnimanion2 = animation2;
            lastPos1 = current1;
            lastPos2 = current2;

        }

    }
}
