

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

	}
	
}
