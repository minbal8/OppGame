namespace GameClient
{
    public class LoadHardSpeedLevel : Command
    {

        public LoadHardSpeedLevel(AbstractLevelFactory receiver) : base(receiver)
        {

        }

        public override Level Execute()
        {
            return receiver.createSpeedLevel();
        }
    }
}
