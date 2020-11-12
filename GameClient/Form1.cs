using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    public partial class Form1 : Form
    {

        private static int StepSize = 3;
        private int dx = 0, dy = 0;
        private int ClientID = 0;

        private static int FPS = 60;
        private float DeltaTime = (1 / (float)FPS);

        private Player clientPlayer;
        private Player friendPlayer;

        SocketSyncer syncer = new SocketSyncer();
        PlayerAnimator playerAnimator;

        Level currentLevel;
        bool PressedUp, PressedBottom, PressedLeft, PressedRight, PressedE;

        private float ActivationTimerCount = 1;

        public Form1()
        {
            InitializeComponent();

            clientPlayer = new Player();
            playerAnimator = new PlayerAnimator(Player1Picture, Player2Picture);

            timer1.Interval = 1000 / 60;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { PressedLeft = true; }
            if (e.KeyCode == Keys.D) { PressedRight = true; }
            if (e.KeyCode == Keys.W) { PressedUp = true; }
            if (e.KeyCode == Keys.S) { PressedBottom = true; }
            if (e.KeyCode == Keys.E) { PressedE = true; }
            e.Handled = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { PressedLeft = false; }
            if (e.KeyCode == Keys.D) { PressedRight = false; }
            if (e.KeyCode == Keys.W) { PressedUp = false; }
            if (e.KeyCode == Keys.S) { PressedBottom = false; }
            if (e.KeyCode == Keys.E) { PressedE = false; }
        }

        private void GetMovementValues()
        {
            dx = 0; dy = 0;
            if (PressedLeft && !PressedRight) { dx = -StepSize; }
            if (PressedRight && !PressedLeft) { dx = StepSize; }
            if (PressedUp && !PressedBottom) { dy = -StepSize; }
            if (PressedBottom && !PressedUp) { dy = StepSize; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetMovementValues();
            CheckCollisions();
            UpdatePlayerPositions();
            UpdateGameState();
            playerAnimator.Update();
        }

        private void UpdateGameState()
        {
            if (ActivationTimerCount > 0)
            {
                ActivationTimerCount -= DeltaTime;
            }

            if (ClientID == 1)
            {
                clientPlayer.PosX = Player1Picture.Location.X;
                clientPlayer.PosY = Player1Picture.Location.Y;
                GameStateSingleton.getInstance().Player1 = clientPlayer;
            }
            if (ClientID == 2)
            {
                clientPlayer.PosX = Player2Picture.Location.X;
                clientPlayer.PosY = Player2Picture.Location.Y;
                GameStateSingleton.getInstance().Player2 = clientPlayer;
            }

        }

        private void CheckCollisions()
        {
            if (currentLevel != null)
            {
                if (ClientID == 1)
                {
                    CheckPlayerCollisions(Player1Picture);
                }
                if (ClientID == 2)
                {
                    CheckPlayerCollisions(Player2Picture);
                }
            }
        }

        private void CheckPlayerCollisions(PictureBox playerPicture)
        {
            dx = currentLevel.CheckHorizontalCollisions(dx, playerPicture, StepSize);
            dy = currentLevel.CheckVerticalCollisions(dy, playerPicture, StepSize);

            if (PressedE && ActivationTimerCount <= 0)
            {
                ActivationTimerCount = 0.3f;
                currentLevel.PressButton(playerPicture);
            }
        }

        private void UpdatePlayerPositions()
        {

            if (ClientID == 0)
                ClientID = GameStateSingleton.getInstance().ClientID;
            if (ClientID == 1)
            {
                Point pos = Player1Picture.Location;
                pos.X += dx;
                pos.Y += dy;
                Player1Picture.Location = pos;


                friendPlayer = GameStateSingleton.getInstance().Player2;
                Player2Picture.Location = new Point(friendPlayer.PosX, friendPlayer.PosY);

            }
            if (ClientID == 2)
            {
                Point pos = Player2Picture.Location;
                pos.X += dx;
                pos.Y += dy;
                Player2Picture.Location = pos;

                friendPlayer = GameStateSingleton.getInstance().Player1;
                Player1Picture.Location = new Point(friendPlayer.PosX, friendPlayer.PosY);
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            syncer.Stop();
        }

        private void TestLevelCollisions()
        {
            AbstractLevelFactory factory = new EasyLevelFactory();
            currentLevel = factory.createLogicLevel();
            currentLevel.DrawWalls(Controls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestLevelCollisions();
            button1.Enabled = false;
            button1.Visible = false;
            syncer.Start();
            Focus();
        }
    }
}
