using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace GameClient
{
    public class Player
    {
        public int PosX { get; set; }

        public int PosY { get; set; }
        public int Animation { get; set; }

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

        private PropertyInfo[] _PropertyInfos = null;

        public override string ToString()
        {
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }

    }


}
