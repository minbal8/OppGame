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
			level = levelBuilder.BuildOuterWalls();

			Assert.IsNotNull(level);
		}

		[TestMethod()]
		public void BuildInnerWallsTest()
		{
			Level level = new LogicLevel();
			LevelBuilder levelBuilder = new LogicLevelBuilder(level);
			level = levelBuilder.BuildInnerWalls();

			Assert.IsNotNull(level);
		}

		[TestMethod()]
		public void BuildTrapsTest()
		{
			Level level = new LogicLevel();
			LevelBuilder levelBuilder = new LogicLevelBuilder(level);
			level = levelBuilder.BuildTraps();

			Assert.IsNotNull(level);
		}

		[TestMethod()]
		public void BuildButtonsAndValvesTest()
		{
			Level level = new LogicLevel();
			LevelBuilder levelBuilder = new LogicLevelBuilder(level);
			level = levelBuilder.BuildButtonsAndValves();

			Assert.IsNotNull(level);
		}

		[TestMethod()]
		public void BuildStartAndFinishAreasTest()
		{
			Level level = new LogicLevel();
			LevelBuilder levelBuilder = new LogicLevelBuilder(level);
			level = levelBuilder.BuildStartAndFinishAreas();

			Assert.IsNotNull(level);
		}
	}
}