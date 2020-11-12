using System.Drawing;

namespace GameClient
{
    public class RunRightCommand : Command
    {
        private SimpleAnimator _animator;
        public RunRightCommand(SimpleAnimator animator) : base(animator)
        {
            _animator = animator;
        }
        public override Image Execute()
        {
            return _animator.RunRight();
        }
    }
}
