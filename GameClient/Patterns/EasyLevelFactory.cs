/**
 * @(#) LogicLevelFactory.cs
 */

namespace GameClient
{
    public class EasyLevelFactory : AbstractLevelFactory
    {
        public override Level createLogicLevel()
        {
            Level level = new LogicLevel();
            LevelBuilder builder = new LogicLevelBuilder(level);
            builder.BuildOuterWalls();
            builder.BuildInnerWalls();
            builder.BuildButtonsAndValves();
            builder.BuildStartAndFinish();

            return level;
        }

        public override Level createSpeedLevel()
        {
            Level level = new SpeedLevel();
            LevelBuilder builder = new SpeedLevelBuilder(level);
            builder.BuildOuterWalls();
            builder.BuildInnerWalls();
            builder.BuildButtonsAndValves();
            builder.BuildStartAndFinish();
            return level;
        }

    }

}
