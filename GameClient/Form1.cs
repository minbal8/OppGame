﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace GameClient
{
    public partial class Form1 : Form
    {

        private static int StepSize = 5;
        private int dx = 0;
        private int dy = 0;

        private int FPS = 60;

        private Player clientPlayer;
        private Player friendPlayer;

        SocketSyncer syncer = new SocketSyncer();
        PlayerAnimator playerAnimator;

        Level currentLevel;

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

            if (e.KeyCode == Keys.A)
            {
                dx = -StepSize;
            }

            if (e.KeyCode == Keys.D)
            {
                dx = StepSize;
            }

            if (e.KeyCode == Keys.W)
            {
                dy = -StepSize;
            }

            if (e.KeyCode == Keys.S)
            {
                dy = StepSize;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                dx = 0;
            }

            if (e.KeyCode == Keys.D)
            {
                dx = 0;
            }

            if (e.KeyCode == Keys.W)
            {
                dy = 0;
            }

            if (e.KeyCode == Keys.S)
            {
                dy = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePlayerPositions();
            UpdateGameState();
            playerAnimator.Update();
            WriteDebugData();
        }

        private void UpdateGameState()
        {
            if (GameStateSingleton.getInstance().ClientID == 1)
            {
                clientPlayer.PosX = Player1Picture.Location.X;
                clientPlayer.PosY = Player1Picture.Location.Y;
                GameStateSingleton.getInstance().Player1 = clientPlayer;
            }
            if (GameStateSingleton.getInstance().ClientID == 2)
            {
                clientPlayer.PosX = Player2Picture.Location.X;
                clientPlayer.PosY = Player2Picture.Location.Y;
                GameStateSingleton.getInstance().Player2 = clientPlayer;
            }

        }

        private void WriteDebugData()
        {
            if (currentLevel != null)
            {
                richTextBox1.Text = currentLevel.ToString() + "\n" + currentLevel.name + "\n";

            }
            else
            {
                richTextBox1.Text = GameStateSingleton.getInstance().ToString();
            }
        }

        private void UpdatePlayerPositions()
        {

            if (GameStateSingleton.getInstance().ClientID == 1)
            {
                Point pos = Player1Picture.Location;
                pos.X += dx;
                pos.Y += dy;
                Player1Picture.Location = pos;

                friendPlayer = GameStateSingleton.getInstance().Player2;
                Player2Picture.Location = new Point(friendPlayer.PosX, friendPlayer.PosY);

            }
            if (GameStateSingleton.getInstance().ClientID == 2)
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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            syncer.Start();
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbstractLevelFactory abstractLevel = new EasyLevelFactory();
            currentLevel = abstractLevel.createLogicLevel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbstractLevelFactory abstractLevel = new HardLevelFactory();
            currentLevel = abstractLevel.createLogicLevel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbstractLevelFactory abstractLevel = new EasyLevelFactory();
            currentLevel = abstractLevel.createSpeedLevel();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbstractLevelFactory abstractLevel = new HardLevelFactory();
            currentLevel = abstractLevel.createSpeedLevel();
        }
    }
}
