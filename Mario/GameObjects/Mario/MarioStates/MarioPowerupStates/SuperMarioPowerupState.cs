using Game1;
using Mario.HeadUpDesign;

namespace Mario.MarioStates.MarioPowerupStates
{
	public class SuperMarioPowerupState : MarioPowerupState
	{
		public SuperMarioPowerupState(IMario mario) : base(mario)
		{

        }

        public override void BeSuper()
		{
			//override NO-OP
		}

		public override void TakeDamage()
		{
			Mario.BeNormal();
            Timer.ExtendTime(TimerUtil.Two);
            Timer.SetTimeRunning(true);
            FloatingTimeBar.CreateNewTimeAnimation(Mario, TimerUtil.Two * TimerUtil.ExtentTime);
        }
    }
}
