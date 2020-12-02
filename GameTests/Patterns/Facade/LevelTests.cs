using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameClient.Tests
{
    [TestClass()]
    public class LevelTests
    {
        [TestMethod()]
        public void UpdateValvesTest()
        {
            Level level = new Level();
            level.AddPart(new Valve(new Point(0, 0), new Point(10, 1)) { PlayerID = 1 });
            level.UpdateValves(1);
            Assert.IsTrue(GameStateSingleton.getInstance().LocalValvesStates.Count > 0);
        }


        [TestMethod()]
        public void CheckHorizontalCollisionsTest()
        {
            Level tempLevel = new Level();
            tempLevel.AddPart(new Wall(new Point(10, 10), new Size(10, 10)));
            PictureBox player = new PictureBox();
            player.Location = new Point(1, 10);
            player.Size = new Size(4, 4);

            int dx = 5;
            dx = tempLevel.CheckHorizontalCollisions(dx, player, 10);
            Assert.AreEqual(0, dx);
        }

        [TestMethod()]
        public void CheckVerticalCollisionsTest()
        {
            Level tempLevel = new Level();
            tempLevel.AddPart(new Wall(new Point(10, 10), new Size(10, 10)));
            PictureBox player = new PictureBox();
            player.Location = new Point(10, 1);
            player.Size = new Size(4, 4);

            int dx = 5;
            dx = tempLevel.CheckVerticalCollisions(dx, player, 10);
            Assert.AreEqual(0, dx);
        }

        [TestMethod()]
        public void PressButtonTest()
        {
            Level level = new Level();
            Button button = new Button(5, 5);
            button.SetAlgorithm(new OpenActivation());
            level.AddPart(button);

            PictureBox player = new PictureBox();
            player.Location = new Point(1, 1);
            player.Size = new Size(5, 5);

            level.PressButton(player);
            Assert.IsTrue(button.CheckCollision(player.Location, player.Size));
            

            
        }
    }
}