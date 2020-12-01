using Game1;
using Mario.Enums;
using Microsoft.Xna.Framework;

namespace Mario.Collision
{
	public class PipeHandler : IBlockCollisionHandler
    {
        public PipeHandler()
        {
        }
        public void HandleCollision(IBlock block, IMario mario,Direction result)
        {
            if (result == Direction.Up&& mario.IsCrouch&&mario.Position.X< GameUtil.UndergroundPosition)
            {
                mario.Position += Vector2.UnitX * CollisionUtil.undergroundOffset;
            }
            else if (result == Direction.Up && mario.IsCrouch && mario.Position.X > GameUtil.UndergroundPosition)
            {
                mario.Position -= new Vector2(CollisionUtil.marioOffesetX, CollisionUtil.marioOffsetY);
            }

        }
    }
}
