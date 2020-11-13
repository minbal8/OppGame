

using System.Drawing;
/**
* @(#) SawTrap.cs
*/
namespace GameClient
{
    public class SawTrap : Trap
    {
        int speed;

        public SawTrap(Point upperLeft, Point bottomRight) : base(upperLeft, bottomRight)
        {
            picture.BackColor = Color.LightGreen;
        }

    }

}
