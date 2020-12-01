using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class DeadMarioMovementState : MarioMovementState
	{
		public DeadMarioMovementState(IMario mario) : base(mario)
		{
			
        }

        public override MarioMovementType MarioMovementType => MarioMovementType.Dead;

		public override bool IsActive()
		{
			return false;
		}
        public override void GoLeft()
        {
            
        }
        public override void GoRight()
        {
        }
    }
}