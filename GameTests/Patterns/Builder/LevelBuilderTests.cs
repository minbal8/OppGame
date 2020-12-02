using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Tests
{
    [TestClass()]
    public class LevelBuilderTests
    {
        [TestMethod()]
        public void BuildOuterWallsTest()
        {
            Level level = new LogicLevel();
            LevelBuilder levelBuilder = new LogicLevelBuilder(level);
            levelBuilder.BuildOuterWalls();


        }

        [TestMethod()]
        public void BuildInnerWallsTest()
        {

        }

        [TestMethod()]
        public void BuildTrapsTest()
        {

        }

        [TestMethod()]
        public void BuildButtonsAndValvesTest()
        {

        }

        [TestMethod()]
        public void BuildStartAndFinishAreasTest()
        {

        }
    }
}