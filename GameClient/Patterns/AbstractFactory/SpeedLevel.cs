namespace GameClient
{
    public class SpeedLevel : Level
    {
        public SpeedLevel(string name) : base(name)
        {

        }

        public SpeedLevel() : this("Speed level")
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
