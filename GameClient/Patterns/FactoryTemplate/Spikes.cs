

using System.Drawing;
/**
* @(#) Spikes.cs
*/
namespace GameClient
{
	public class Spikes : Trap
	{
		public int state { get; set; }

		public Spikes(Point upperLeft, Point bottomRight) : base(upperLeft, bottomRight)
		{
			picture.BackColor = Color.DarkGray;
		}

        protected sealed override void DealDamage()
        {
            int id = GameStateSingleton.getInstance().ClientID;
            if (id == 1)
            {
                GameStateSingleton.getInstance().Player1.TakeDamage(10);
            }
            if (id == 2)
            {
                GameStateSingleton.getInstance().Player2.TakeDamage(10);
            }
        }

        protected sealed override void UpdateTrapState()
        {
            System.Console.WriteLine("Updating trap state...");
        }
    }
	
}
