namespace GameClient
{
    // invoker class
    public class LevelSelect
    {
        private Command _command;
        public void SetCommand(Command command)
        {
            _command = command;
        }
        public Level Execute()
        {
            return _command.Execute();
        }
    }
}
