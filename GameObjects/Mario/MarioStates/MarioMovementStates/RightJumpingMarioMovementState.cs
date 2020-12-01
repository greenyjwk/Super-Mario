using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class RightJumpingMarioMovementState : MarioMovementState
	{
		public RightJumpingMarioMovementState(IMario mario):base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.RightJump;

		public override void GoDown()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}
        public override void GoLeft()
        {
            //No need to left
        }

	
	}
}