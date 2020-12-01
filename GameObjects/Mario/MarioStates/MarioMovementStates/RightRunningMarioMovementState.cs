using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Enums;
using Game1;
namespace Mario.MarioStates.MarioMovementStates
{
	class RightRunningMarioMovementState : MarioMovementState
	{
		public RightRunningMarioMovementState(IMario mario) : base(mario)
		{

		}
		public override MarioMovementType MarioMovementType => MarioMovementType.RightRun;

		public override void GoUp()
		{
			Mario.MarioMovementState = new RightJumpingMarioMovementState(Mario);
        }
		public override void GoLeft()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
            Mario.Physics.MoveLeft();
        }

        public override void GoDown()
		{
			Mario.MarioMovementState = new RightCrouchingMarioMovementState(Mario);
		}

		public override void NoInput()
		{
			Mario.MarioMovementState = new RightIdleMarioMovementState(Mario);
		}
	}
}
