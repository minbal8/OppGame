using System.Drawing;

namespace GameClient
{
    public class StandLeftCommand : Command
    {
        private SimpleAnimator _animator;
        public StandLeftCommand(SimpleAnimator animator) : base(animator)
        {
            _animator = animator;
        }
        public override Image Execute()
        {
            return _animator.StandLeft();
        }
    }
}
