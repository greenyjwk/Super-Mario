using Game1;
using Mario.Enums;
using Mario.MarioStates.MarioPowerupStates;

namespace Mario.Collision.MarioCollisionHandler.MarioItemCollisionHandler
{
	public class MarioStarmanCollisionHandler : IMarioCollisionHandler
    {
        public MarioStarmanCollisionHandler()
        {
        }
        public void HandleCollision(IMario mario, Direction result)
        {
            if (mario.MarioPowerupState is NormalMarioPowerupState
                || mario.MarioPowerupState is SuperMarioPowerupState
                || mario.MarioPowerupState is FireMarioPowerupState)
            {
                mario.BeStar();
            }
        }
    }
}
