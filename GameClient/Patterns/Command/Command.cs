using System.Drawing;

namespace GameClient
{
    public abstract class Command
    {
        protected SimpleAnimator receiver;

        public Command(SimpleAnimator receiver)
        {
            this.receiver = receiver;
        }

        public abstract Image Execute();

    }
}
