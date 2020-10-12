
namespace GameClient
{
	public class HardLevelFactory : AbstractLevelFactory
	{
		public override Level createLogicLevel()
		{
			return new LogicLevel();
		}

		public override Level createSpeedLevel()
		{
			return new SpeedLevel();
		}
	}
	
}
