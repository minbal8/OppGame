using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class RunningRightState : PlayerState
    {
        public RunningRightState(string imagePath) : base(imagePath)
        { }

        public override Image ChangeState()
        {
            return stateImage;
        }
    }
}
