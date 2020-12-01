using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class LeftRunningMarioMovementState : MarioMovementState
	{
		public LeftRunningMarioMovementState(IMario mario) : base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.LeftRun;

		public override void GoDown()
		{
			Mario.MarioMovementState = new LeftCrouchingMarioMovementState(Mario);
		}

		public override void GoRight()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
            Mario.Physics.MoveRight();

        }

        public override void GoUp()
		{
			Mario.MarioMovementState = new LeftJumpingMarioMovementState(Mario);
        }

		public override void NoInput()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
		}
       
    }
}