using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameClient.Tests
{
    [TestClass()]
    public class LevelTests
    {
        [TestMethod()]
        public void UpdateValvesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckHorizontalCollisionsTest()
        {
            Level tempLevel = new Level();
            tempLevel.AddPart(new Wall(new Point(1,1), new Point(10, 10)));

            Assert.Fail();
        }

        [TestMethod()]
        public void CheckVerticalCollisionsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PressButtonTest()
        {
            Assert.Fail();
        }
    }
}