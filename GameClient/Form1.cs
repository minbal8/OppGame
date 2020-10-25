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

        private int FPS = 60;

        private Player clientPlayer;
        private Player friendPlayer;

        SocketSyncer syncer = new SocketSyncer();
        PlayerAnimator playerAnimator;

        Level currentLevel;
        bool up, bottom, left, right;

        public Form1()
        {
            InitializeComponent();

            clientPlayer = new Player();
            playerAnimator = new PlayerAnimator(Player1Picture, Player2Picture);

            timer1.Interval = 1000 / FPS;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { bottom = true; }
            e.Handled = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { bottom = false; }
        }

        private void GetMovementValues()
        {
            dx = 0; dy = 0;
            if (left && !right) { dx = -StepSize; }
            if (right && !left) { dx = StepSize; }
            if (up && !bottom) { dy = -StepSize; }
            if (bottom && !up) { dy = StepSize; }
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
                    dx = currentLevel.CheckHorizontalCollisions(dx, Player1Picture, StepSize);
                    dy = currentLevel.CheckVerticalCollisions(dy, Player1Picture, StepSize);
                }
                if (ClientID == 2)
                {
                    dx = currentLevel.CheckHorizontalCollisions(dx, Player2Picture, StepSize);
                    dy = currentLevel.CheckVerticalCollisions(dy, Player2Picture, StepSize);
                }
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
            currentLevel = factory.createSpeedLevel();
            currentLevel.DrawWalls(Controls);

            Button but = new Button(100, 100);
            Controls.Add(but.image);


            Console.WriteLine(MousePosition.X);

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
