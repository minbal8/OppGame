

using System.Drawing;
/**
* @(#) SawTrap.cs
*/
namespace GameClient
{
    public class SawTrap : Trap
    {
        public SawTrap(Point upperLeft, Point bottomRight) : base(upperLeft, bottomRight)
        {
            picture.BackColor = Color.LightGreen;
        }

        protected sealed override void DealDamage()
        {

            GameStateSingleton.getInstance().DealDamageToPlayer(30);
            timeOnTrap = 0;
        }

        protected sealed override void UpdateTrapState()
        {
            if (timeOnTrap > 3f)
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
