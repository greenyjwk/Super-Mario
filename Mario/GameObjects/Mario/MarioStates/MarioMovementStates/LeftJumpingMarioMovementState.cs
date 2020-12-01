using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftJumpingMarioMovementState : MarioMovementState
	{
		public LeftJumpingMarioMovementState(IMario mario) : base(mario)
		{

        }

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftJump;

		public override void GoDown()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}
        public override void GoRight()
        {
            //No need to right
        }

		
	}
}