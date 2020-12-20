

using System.Drawing;
/**
* @(#) Spikes.cs
*/
namespace GameClient
{
    public class Spikes : Trap
    {


        public Spikes(Point upperLeft, Point bottomRight) : base(upperLeft, bottomRight)
        {
            picture.BackColor = Color.DarkGray;
        }

        protected sealed override void UpdateTrapState()
        {
            if (timeOnTrap > 1f)
            {
                isDamaging = true;
            }
            else
            {
                isDamaging = false;
            }
        }

        protected sealed override void DealDamage()
        {

            GameStateSingleton.getInstance().DealDamageToPlayer(30);
            timeOnTrap = 0;
        }


    }

}
