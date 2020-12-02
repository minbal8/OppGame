using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Tests
{
    [TestClass()]
    public class LevelSelectTests
    {
        [TestMethod()]
        public void LoadEasyLogicLevelTest()
        {
            AbstractLevelFactory easyLevelFactory = new EasyLevelFactory();
            LoadEasyLogicLevel easyLogicLevel = new LoadEasyLogicLevel(easyLevelFactory);
            var temp = easyLogicLevel.Execute();
            Assert.IsTrue(temp is LogicLevel);

        }

        [TestMethod()]
        public void LoadEasySpeedLevelTest()
        {
            AbstractLevelFactory easyLevelFactory = new EasyLevelFactory();
            LoadEasySpeedLevel easyLogicLevel = new LoadEasySpeedLevel(easyLevelFactory);
            var temp = easyLogicLevel.Execute();
            Assert.IsTrue(temp is SpeedLevel);
        }

        [TestMethod()]
        public void LoadHardLogicLevelTest()
        {
            AbstractLevelFactory easyLevelFactory = new HardLevelFactory();
            LoadHardLogicLevel easyLogicLevel = new LoadHardLogicLevel(easyLevelFactory);
            var temp = easyLogicLevel.Execute();
            Assert.IsTrue(temp is LogicLevel);
        }

        [TestMethod()]
        public void LoadHardSpeedLevelTest()
        {
            AbstractLevelFactory easyLevelFactory = new HardLevelFactory();
            LoadHardSpeedLevel easyLogicLevel = new LoadHardSpeedLevel(easyLevelFactory);
            var temp = easyLogicLevel.Execute();
            Assert.IsTrue(temp is SpeedLevel);
        }
    }
}