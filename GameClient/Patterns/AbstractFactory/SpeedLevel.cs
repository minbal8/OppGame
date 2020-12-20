namespace GameClient
{
    public class SpeedLevel : Level
    {
        public SpeedLevel()
        {

        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public string ConcreteSpeedLevelMethod()
        {
            return "Returned string from Speed level";
        }

    }
}
