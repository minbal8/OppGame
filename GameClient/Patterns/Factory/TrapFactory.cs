

using System.Drawing;
/**
* @(#) TrapFactory.cs
*/
namespace GameClient
{
    public class TrapFactory : Factory
    {
        public override Trap CreateTrap(int trapType, Point location, Point size)
        {
            switch (trapType)
            {
                case 1:
                    return new FallTrap(location, size);

                case 2:
                    return new SawTrap(location, size);

                case 3:
                    return new Spikes(location, size);

                default:
                    return null;

            }
        }

    }

}
