using System;

namespace GameClient
{
    public class Player
    {
        public int PosX { get; set; }

        public int PosY { get; set; }
        public int Animation { get; set; }
        private int Health = 100;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Console.WriteLine("PlayerDied");
        }


        /*
        private PictureBox picture;

        public void SetPlayerPicture(PictureBox picture)
        {
            this.picture = picture;
        }

        public void addDecoration(PictureBox decoration)
        {
            picture.Controls.Add(decoration);
        }

        public void removeDecoration(PictureBox decoration)
        {
            picture.Controls.Remove(decoration);
        }

        */
    }


}
