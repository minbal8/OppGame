using System;

namespace GameClient
{
    public class OpenActivation : ButtonAlgorithm
    {
        public override int Activate()
        {
            Console.WriteLine("Opened");
            return 1;
        }
    }
}
