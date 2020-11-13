
namespace GameClient
{
    public class HardLevelFactory : AbstractLevelFactory
    {
        public override Level createLogicLevel()
        {
            Level level = new LogicLevel();
            LevelBuilder builder = new LogicLevelBuilder(level);
            builder.BuildOuterWalls();
            builder.BuildInnerWalls();
            builder.BuildButtonsAndValves();
            builder.BuildTraps();
            builder.BuildStartAndFinishAreas();

            return level;
        }

        public override Level createSpeedLevel()
        {
            Level level = new SpeedLevel();
            LevelBuilder builder = new SpeedLevelBuilder(level);
            builder.BuildOuterWalls();
            builder.BuildInnerWalls();
            builder.BuildTraps();
            builder.BuildStartAndFinishAreas();

            return level;
        }
    }

}
