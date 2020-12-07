

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

        protected sealed override void DealDamage()
        {
            int id = GameStateSingleton.getInstance().ClientID;
            if (id == 1)
            {
                GameStateSingleton.getInstance().Player1.TakeDamage(30);
            }
            if (id == 2)
            {
                GameStateSingleton.getInstance().Player2.TakeDamage(30);
            }
        }

        protected sealed override void UpdateTrapState()
        {
            System.Console.WriteLine("Updating trap state...");
        }
    }

}
