using System.Drawing;

namespace GameClient
{
    public class RunLeftCommand : Command
    {
        private SimpleAnimator _animator;
        public RunLeftCommand(SimpleAnimator animator) : base(animator)
        {
            _animator = animator;
        }
        public override Image Execute()
        {
            return _animator.RunLeft();
        }
    }
}
