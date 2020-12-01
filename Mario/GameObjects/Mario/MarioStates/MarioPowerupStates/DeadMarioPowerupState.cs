using Game1;
using Mario.Enums;
using Mario.Sound;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class DeadMarioPowerupState : MarioPowerupState
	{
		public DeadMarioPowerupState(IMario mario) : base(mario)
		{
            SoundManager.StopSong();
			SoundManager.Instance.PlaySoundEffect("marioDie");

        }

        public override bool IsActive()
		{
			return false;
		}
		public override void BeDead()
		{
		}
	}
}