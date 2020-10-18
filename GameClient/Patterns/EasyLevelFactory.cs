/**
 * @(#) LogicLevelFactory.cs
 */

namespace GameClient
{
	public class EasyLevelFactory : AbstractLevelFactory
	{
		public override Level createLogicLevel()
		{
			var temp = new LogicLevel("EasyLogicLevel.txt");
			temp.name = "Easy logic level";
			return temp;
		}

		public override Level createSpeedLevel()
		{
			var temp = new SpeedLevel();
			temp.name = "Easy speed level";
			return temp;
		}
		
	}
	
}
