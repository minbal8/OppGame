

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
            int id = GameStateSingleton.getInstance().ClientID;
            if (id == 1)
            {
                GameStateSingleton.getInstance().Player1.TakeDamage(100);
            }
            if (id == 2)
            {
                GameStateSingleton.getInstance().Player2.TakeDamage(100);
            }
        }

        protected sealed override void UpdateTrapState()
        {
            System.Console.WriteLine("Updating trap state...");
        }
    }

}
