using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameClient.Patterns.Interpreter;

namespace GameClient
{
    public partial class Form1 : Form
    {

        private static int StepSize = 3;
        private int dx = 0, dy = 0;
        private int ClientID = 0;

        private static int FPS = 60;
        public static float DeltaTime = (1 / (float)FPS);

        private Player clientPlayer;
        private Player friendPlayer;

        SocketSyncer syncer = new SocketSyncer();
        PlayerAnimator playerAnimator;

        Level currentLevel;
        bool PressedUp, PressedBottom, PressedLeft, PressedRight, PressedE;
        bool PressedZ, PressedX, PressedC, PressedV, Pressed1, Pressed2, Pressed3, Pressed4;
        private string firstChar = "", secondChar = "";

        private FirstChatUser c1;
        private SecondChatUser c2;

        private float ActivationTimerCount = 1;

        public Form1()
        {
            InitializeComponent();

            clientPlayer = new Player();
            playerAnimator = new PlayerAnimator(Player1Picture, Player2Picture);

            ChatScreen screen = new ChatScreen();
            c1 = new FirstChatUser(screen);
            screen.ChatUser1 = c1;
            c2 = new SecondChatUser(screen);
            screen.ChatUser2 = c2;

            timer1.Interval = 1000 / 60;
            timer1.Start();
        }

        #region PlayerInput

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { PressedLeft = true; }
            if (e.KeyCode == Keys.D) { PressedRight = true; }
            if (e.KeyCode == Keys.W) { PressedUp = true; }
            if (e.KeyCode == Keys.S) { PressedBottom = true; }
            if (e.KeyCode == Keys.E) { PressedE = true; }
            if (e.KeyCode == Keys.NumPad1) { firstChar = "1"; }
            if (e.KeyCode == Keys.NumPad2) { firstChar = "2"; }
            if (e.KeyCode == Keys.NumPad3) { firstChar = "3"; }
            if (e.KeyCode == Keys.NumPad4) { firstChar = "4"; }
            if (e.KeyCode == Keys.Z) { secondChar = "z"; }
            if (e.KeyCode == Keys.X) { secondChar = "x"; }
            if (e.KeyCode == Keys.C) { secondChar = "c"; }
            if (e.KeyCode == Keys.V) { secondChar = "v"; }

            if (ClientID == 1)
            {
                if (firstChar != "" && secondChar != "")
                {
                    c1.Send(InterpreterTest(firstChar + secondChar));
                    GameStateSingleton.getInstance().Player1.Message = firstChar + secondChar;
                }
            }
            else
            {
                if (firstChar != "" && secondChar != "")
                {
                    c2.Send(InterpreterTest(firstChar + secondChar));
                    GameStateSingleton.getInstance().Player2.Message = firstChar + secondChar;
                }
            }

            e.Handled = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { PressedLeft = false; }
            if (e.KeyCode == Keys.D) { PressedRight = false; }
            if (e.KeyCode == Keys.W) { PressedUp = false; }
            if (e.KeyCode == Keys.S) { PressedBottom = false; }
            if (e.KeyCode == Keys.E) { PressedE = false; }
            if (e.KeyCode == Keys.NumPad1) { firstChar = ""; }
            if (e.KeyCode == Keys.NumPad2) { firstChar = ""; }
            if (e.KeyCode == Keys.NumPad3) { firstChar = ""; }
            if (e.KeyCode == Keys.NumPad4) { firstChar = ""; }
            if (e.KeyCode == Keys.Z) { secondChar = ""; }
            if (e.KeyCode == Keys.X) { secondChar = ""; }
            if (e.KeyCode == Keys.C) { secondChar = ""; }
            if (e.KeyCode == Keys.V) { secondChar = ""; }

        }
        private void GetMovementValues()
        {
            dx = 0; dy = 0;
            if (PressedLeft && !PressedRight) { dx = -StepSize; }
            if (PressedRight && !PressedLeft) { dx = StepSize; }
            if (PressedUp && !PressedBottom) { dy = -StepSize; }
            if (PressedBottom && !PressedUp) { dy = StepSize; }
        }

        #endregion

        #region GameLogic
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetMovementValues();
            CheckCollisions();
            UpdatePlayerPositions();
            UpdateGameState();
            CheckForMessages();
            playerAnimator.Update();
        }


        private void UpdateGameState()
        {
            ChatScreen screen = new ChatScreen();
            FirstChatUser c1 = new FirstChatUser(screen);
            screen.ChatUser1 = c1;
            SecondChatUser c2 = new SecondChatUser(screen);
            screen.ChatUser2 = c2;

            if (ActivationTimerCount > 0)
            {
                ActivationTimerCount -= DeltaTime;
            }

            if (ClientID == 1)
            {
                //if (firstChar != "" && secondChar != "")
                //{
                //    c1.Send(InterpreterTest(firstChar + secondChar));
                //}



                clientPlayer = GameStateSingleton.getInstance().Player1;
                clientPlayer.PosX = Player1Picture.Location.X;
                clientPlayer.PosY = Player1Picture.Location.Y;
                GameStateSingleton.getInstance().Player1 = clientPlayer;
            }
            if (ClientID == 2)
            {
                //if (firstChar != "" && secondChar != "")
                //{
                //    c2.Send(InterpreterTest(firstChar + secondChar));
                //}

                clientPlayer = GameStateSingleton.getInstance().Player2;
                clientPlayer.PosX = Player2Picture.Location.X;
                clientPlayer.PosY = Player2Picture.Location.Y;
                GameStateSingleton.getInstance().Player2 = clientPlayer;

            }

            if (currentLevel != null)
                currentLevel.UpdateValves(ClientID);


            label1.Text = "Player1: " + GameStateSingleton.getInstance().Player1.Health;
            label2.Text = "Player2: " + GameStateSingleton.getInstance().Player2.Health;
        }

        private void CheckForMessages()
        {

            string message1 = GameStateSingleton.getInstance().Player1.Message;
            string message2 = GameStateSingleton.getInstance().Player2.Message;

            chatTextField.Text = "";
            if (message1.Length > 0)
            {
                var temp = message1;
                // some magic happens here with temp


                chatTextField.Text += temp + "\n";
            }

            if (message2.Length > 0)
            {
                var temp = message2;
                // some magic happens here with temp

                chatTextField.Text += temp;
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

            currentLevel.CheckTraps(playerPicture);

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
        #endregion

        private void LoadLevel()
        {
            AbstractLevelFactory easyLevelFactory = new EasyLevelFactory();
            AbstractLevelFactory hardLevelFactory = new HardLevelFactory();

            LoadEasyLogicLevel easyLogicLevel = new LoadEasyLogicLevel(easyLevelFactory);
            LoadEasySpeedLevel easySpeedLevel = new LoadEasySpeedLevel(easyLevelFactory);

            LoadHardLogicLevel hardLogicLevel = new LoadHardLogicLevel(hardLevelFactory);
            LoadHardSpeedLevel hardSpeedLevel = new LoadHardSpeedLevel(hardLevelFactory);

            LevelSelect levelSelect = new LevelSelect();

            while (GameStateSingleton.getInstance().LevelID == 0)
            {

            }
            int id = GameStateSingleton.getInstance().LevelID;

            switch (id)
            {
                case 1:
                    levelSelect.SetCommand(easyLogicLevel);
                    break;

                case 2:
                    levelSelect.SetCommand(easySpeedLevel);
                    break;

                case 3:
                    levelSelect.SetCommand(hardLogicLevel);
                    break;

                case 4:
                    levelSelect.SetCommand(hardSpeedLevel);
                    break;

                default:
                    break;
            }

            currentLevel = levelSelect.Execute();
            currentLevel.DrawLevel(Controls);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            syncer.Stop();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = false;
            syncer.Start();
            LoadLevel();
            Focus();
            DecoratorTest();
            PrototypeTest();
            VisitorTest();
            //CompositeTest();
            //MediatorTest();
            ChainOfResponsibility();
        }

        private void VisitorTest()
        {
            Visitor playerVisitor = new PlayerVisitor();
            Visitor spectatorVisitor = new SpectatorVisitor();

            Level speed = new SpeedLevel();
            Level logic = new LogicLevel();

            speed.Accept(playerVisitor);
            speed.Accept(spectatorVisitor);

            logic.Accept(playerVisitor);
            logic.Accept(spectatorVisitor);


        }

        private void MediatorTest()
        {
            ChatScreen screen = new ChatScreen();

            FirstChatUser c1 = new FirstChatUser(screen);
            SecondChatUser c2 = new SecondChatUser(screen);

            screen.ChatUser1 = c1;
            screen.ChatUser2 = c2;

            c1.Send(InterpreterTest("1z"));
            c2.Send(InterpreterTest("2x"));
        }

        private string InterpreterTest(string sentence)
        {
            //string sentence = "1x";
            Context context = new Context(sentence);

            List<SentenceExpression> sentenceExpressionList = new List<SentenceExpression>();
            sentenceExpressionList.Add(new Verb());
            sentenceExpressionList.Add(new Adverb());

            foreach (SentenceExpression exp in sentenceExpressionList)
            {
                exp.Interpret(context);
            }
            return context.Output;
        }

        private void DecoratorTest()
        {
            Wearable hat = new Hat(Player1Picture);
            hat.ItemColor = new Red();

            Wearable scarf = new Scarf_tmp(Player1Picture);
            scarf.ItemColor = new Blue();

            DefaultSkin ds = new DefaultSkin();

            hat.setSkin(ds);
            scarf.setSkin(hat);
            scarf.Skin();

            //RedHat rh = new RedHat(Player1Picture);
            //Scarf s = new Scarf(Player1Picture);
            //BlueHat bh = new BlueHat(Player1Picture);


            ////rh.setSkin(ds);
            //s.setSkin(ds);
            //bh.setSkin(s);
            //bh.Skin();
        }

        private void PrototypeTest()
        {
            Hat hat = new Hat(Player1Picture);
            Hat cloneHat = (Hat)hat.Clone();
            Console.WriteLine("Clone: {0}", cloneHat.GetPlayerPosition());
        }


        private void CompositeTest()
        {
            // Create a tree structure

            LevelComposite root = new LevelComposite("Menu");

            LevelComposite comp = new LevelComposite("Speed Levels");
            comp.Add(new Level("EasySpeedLevel"));
            comp.Add(new Level("HardSpeedLevel"));
            root.Add(comp);

            LevelComposite comp1 = new LevelComposite("Logic Levels");
            comp1.Add(new Level("EasyLogicLevel"));
            comp1.Add(new Level("HardLogicLevel"));
            root.Add(comp1);

            // Recursively display tree
            root.DisplayTree(1);
        }

        private void ChainOfResponsibility()
        {
            Handler win = new NextLevelHandler();
            Handler loose = new ReturnToLevelHandler();
            win.SetSuccessor(loose);
            loose.SetSuccessor(win);

            int[] lostOrWon = { 0, 0, 1, 1, 0, 1, 1, 1, 0, 1 };

            foreach (int status in lostOrWon)
            {
                win.HandleRequest(status);
            }
        }

    }
}
