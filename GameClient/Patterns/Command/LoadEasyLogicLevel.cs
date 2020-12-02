namespace GameClient
{
    public class LoadEasyLogicLevel : Command
    {

        public LoadEasyLogicLevel(AbstractLevelFactory receiver) : base(receiver)
        {

        }

        public override Level Execute()
        {
            return receiver.createLogicLevel();
        }
    }
}
