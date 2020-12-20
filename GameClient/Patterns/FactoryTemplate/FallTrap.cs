

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
        }

        protected sealed override void DealDamage()
        {

            GameStateSingleton.getInstance().DealDamageToPlayer(30);
            timeOnTrap = 0;
        }

        protected sealed override void UpdateTrapState()
        {
            if (timeOnTrap > 5f)
            {
                isDamaging = true;
            }
            else
            {
                isDamaging = false;
            }
        }
    }

}
