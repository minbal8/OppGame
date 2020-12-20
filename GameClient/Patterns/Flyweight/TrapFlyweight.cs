using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class TrapFlyweight : Flyweight
    {

        Dictionary<Type, Image> images = new Dictionary<Type, Image>();

        public Image getImage(Type trapType)
        {
            if (!images.ContainsKey(trapType))
            {
                images.Add(trapType, Image.FromFile("Images/" + trapType.Name + ".png"));
            }
            return images[trapType];
        }

        public Image getImage2(Type trapType)
        {
            return Image.FromFile("Images/" + trapType.Name + ".png");

        }
    }
}
