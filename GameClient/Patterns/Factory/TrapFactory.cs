

using System.Drawing;
/**
* @(#) TrapFactory.cs
*/
namespace GameClient
{
    public class TrapFactory : Factory
    {
        Flyweight trapFlyweight = new TrapFlyweight();
        public override Trap CreateTrap(int trapType, Point location, Point size)
        {
            Trap returnTrap;
            switch (trapType)
            {
                case 1:
                    returnTrap = new FallTrap(location, size);
                    break;
                case 2:
                    returnTrap = new SawTrap(location, size);
                    break;
                case 3:
                    returnTrap = new Spikes(location, size);
                    break;
                default:
                    returnTrap = null;
                    break;
            }
            returnTrap.GetType();
            var image = trapFlyweight.getImage(returnTrap.GetType());
            returnTrap.SetImage(image);
            return returnTrap;
        }

    }

}
