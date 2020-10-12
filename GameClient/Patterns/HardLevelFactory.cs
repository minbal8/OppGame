
namespace GameClient
{
	public class HardLevelFactory : AbstractLevelFactory
	{
		public override Level createLogicLevel()
		{
			var temp = new LogicLevel();
			temp.name = "Hard logic level";
			return temp;
		}

		public override Level createSpeedLevel()
		{
			var temp = new SpeedLevel();
			temp.name = "Hard speed level";
			return temp;
		}
	}
	
}
