

using System.Drawing;
/**
* @(#) TrapFactory.cs
*/
namespace GameClient
{
    public class TrapFactory : Factory
    {
        TrapFlyweight trapFlyweight = new TrapFlyweight();
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

            var image = trapFlyweight.getImage(returnTrap.GetType());
            //var image = trapFlyweight.getImage2(returnTrap.GetType()); // Greitaveikos testui metodas be Flyweight
            returnTrap.SetImage(image);
            return returnTrap;
        }

    }

}
