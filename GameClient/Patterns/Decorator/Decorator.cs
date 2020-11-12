using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class Decorator : Skin
    {
        protected Skin skin;

        public void setSkin(Skin skin)
        {
            this.skin = skin;
        }

        public void Skin()
        {
            if (skin != null)
            {
                skin.Skin();
            }
        }
    }
}
