

using System.Drawing;
/**
* @(#) FallTrap.cs
*/
namespace GameClient
{
    public class FallTrap : Trap
    {
        int state;

        public FallTrap(Point upperLeft, Point bottomRight) : base(upperLeft, bottomRight)
        {
            picture.BackColor = Color.Pink;
        }
    }

}
