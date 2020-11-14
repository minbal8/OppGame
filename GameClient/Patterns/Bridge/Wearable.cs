using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    abstract class Wearable : Decorator
    {

        protected ItemColor itemColor;

        public ItemColor ItemColor
        {
            set { itemColor = value; }
        }

        public virtual string Draw()
        {
            return itemColor.Color();
        }

        public override void Skin()
        {
            Draw();
            skin.Skin();
            //base.Skin();
            
        }
        //public abstract void Draw();
    }
}
