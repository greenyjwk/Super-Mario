using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
	internal class RightIdleMarioMovementState : MarioMovementState
	{
		public RightIdleMarioMovementState(IMario mario) : base(mario)
		{
		}

		public override MarioMovementType MarioMovementType => MarioMovementType.RightIdle;

		public override void GoUp()
		{
			Mario.MarioMovementState = new RightJumpingMarioMovementState(Mario);
        }
		public override void GoDown()
		{
			Mario.MarioMovementState = new RightCrouchingMarioMovementState(Mario);
		}

		public override void GoLeft()
		{
			Mario.MarioMovementState = new LeftIdleMarioMovementState(Mario);
            Mario.Physics.MoveLeft();

        }

        public override void GoRight()
		{
			Mario.MarioMovementState = new RightRunningMarioMovementState(Mario);
            Mario.Physics.MoveRight();

        }

    }
}