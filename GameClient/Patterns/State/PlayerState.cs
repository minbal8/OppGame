using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    public abstract class PlayerState
    {
        public PlayerState(string path)
        {
            stateImage = Image.FromFile(path);
        }

        public Image stateImage { get; set; }
        public abstract Image ChangeState();

    }
}
