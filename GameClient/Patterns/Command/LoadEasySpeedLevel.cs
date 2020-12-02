namespace GameClient
{
    public class LoadEasySpeedLevel : Command
    {

        public LoadEasySpeedLevel(AbstractLevelFactory receiver) : base(receiver)
        {

        }

        public override Level Execute()
        {
            return receiver.createSpeedLevel();
        }
    }
}
