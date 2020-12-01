using Game1;
using Mario.Enums;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sound;

namespace Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler
{
	public class MarioMagicMushroomCollisionHandler : IMarioCollisionHandler
    {
        public MarioMagicMushroomCollisionHandler()
        {
			SoundManager.Instance.PlaySoundEffect("marioPowerUp");
        }
        public void HandleCollision(IMario mario, Direction result)
        {
            if ((mario.MarioPowerupState is NormalMarioPowerupState)
                           && !mario.IsStarMario())
            {
                mario.BeSuper();
            }
        }


    }
}
