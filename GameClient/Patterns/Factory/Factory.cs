

using System.Drawing;

namespace GameClient
{
    public abstract class Factory
    {
        public abstract Trap CreateTrap(int trapType, Point upperLeft, Point bottomDown);

    }

}
