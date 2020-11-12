using System.Drawing;

namespace GameClient
{
    public class StandRightCommand : Command
    {
        private SimpleAnimator _animator;
        public StandRightCommand(SimpleAnimator animator) : base(animator)
        {
            _animator = animator;
        }
        public override Image Execute()
        {
            return _animator.StandRight();
        }
    }
}
