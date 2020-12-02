namespace GameClient
{
    public class LoadHardLogicLevel : Command
    {

        public LoadHardLogicLevel(AbstractLevelFactory receiver) : base(receiver)
        {

        }

        public override Level Execute()
        {
            return receiver.createLogicLevel();
        }
    }
}
