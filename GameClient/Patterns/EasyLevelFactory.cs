/**
 * @(#) LogicLevelFactory.cs
 */

namespace GameClient
{
	public class EasyLevelFactory : AbstractLevelFactory
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
