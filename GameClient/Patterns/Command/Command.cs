namespace GameClient
{
    public abstract class Command
    {
        protected AbstractLevelFactory receiver;

        public Command(AbstractLevelFactory receiver)
        {
            this.receiver = receiver;
        }

        public abstract Level Execute();

    }
}
