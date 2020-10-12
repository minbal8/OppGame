/**
 * @(#) TrapFactory.cs
 */

namespace ClassDiagram
{
    public class TrapFactory : Factory
    {
        public override Trap CreateTrap(string trapType)
        {
            switch (trapType)
            {
                case "SawTrap":
                    return new SawTrap();
                case "FallTrap":
                    return new FallTrap();
                case "Spikes":
                    return new Spikes();
                default: return null;
            }

        }

    }

}
