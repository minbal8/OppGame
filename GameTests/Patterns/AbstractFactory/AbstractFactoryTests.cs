using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;

namespace GameClient.Tests
{
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void CreateEasyLogicLevelTest()
        {
            AbstractLevelFactory factory = new EasyLevelFactory();
            var temp = factory.createLogicLevel();
            Assert.IsTrue(temp is LogicLevel);
        }

        [TestMethod]
        public void CreateHardLogicLevelTest()
        {
            AbstractLevelFactory factory = new HardLevelFactory();
            var temp = factory.createLogicLevel();
            Assert.IsTrue(temp is LogicLevel);
        }

        [TestMethod]
        public void CreateEasySpeedLevelTest()
        {
            AbstractLevelFactory factory = new EasyLevelFactory();
            var temp = factory.createSpeedLevel();
            Assert.IsTrue(temp is SpeedLevel);
        }

        [TestMethod]
        public void CreateHardSpeedLevelTest()
        {
            AbstractLevelFactory factory = new HardLevelFactory();
            var temp = factory.createSpeedLevel();
            Assert.IsTrue(temp is SpeedLevel);
        }

    }
}
