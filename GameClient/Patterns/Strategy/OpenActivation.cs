using System;

namespace GameClient
{
    class OpenActivation : ButtonAlgorithm
    {
        public override int Activate()
        {
            Console.WriteLine("Opened");
            return 1;
        }
    }
}
