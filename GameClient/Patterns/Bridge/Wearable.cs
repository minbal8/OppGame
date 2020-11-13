using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    abstract class Wearable : Decorator
    {
        protected ItemColor itemColor;

        public ItemColor ItemColor
        {
            set { itemColor = value; }
        }

        public virtual void Draw()
        {
            itemColor.Color();
        }

        public override void Skin()
        {
            skin.Skin();
            //base.Skin();
            Draw();
        }
        //public abstract void Draw();

    }
}
