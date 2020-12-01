using Game1;
using Mario.Enums;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sound;

namespace Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler
{
	public class OneUpMushroomCollisionHandler : IMarioCollisionHandler
    {
        public OneUpMushroomCollisionHandler()
        {
			SoundManager.Instance.PlaySoundEffect(SoundString.marioOneUp);
        }
        public void HandleCollision(IMario mario, Direction result)
        {
            LifeCounter.Instance.IncreaseLife();
        }


    }
}
