using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Microsoft.Xna.Framework;

namespace Mario.Collision.FireballCollisionHandler
{
	public class FireballBlockCollisionHandler : IProjectileCollisionHandler
    {
        IBlock block;
        Rectangle intersection;
        Direction result;
        public FireballBlockCollisionHandler(IBlock block, Rectangle intersection,Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IProjectile fireball)
        {
            if (!(block.BlockState is HiddenBlockState))
            {
                IsOnLand(fireball);
                FireballAdjustment(fireball);
            }
        }
        public void FireballAdjustment(IProjectile fireball)
        {
                switch (result)
                {
                    case Direction.Up:
                        fireball.Position -= Vector2.UnitY * intersection.Height;
                        break;
                    case Direction.Down:
                        fireball.Position += Vector2.UnitY * intersection.Height;
                        break;
                    case Direction.Left:
                    if (block.BlockState is UnbreakableBlockState)
                        fireball.Position -= Vector2.UnitX * intersection.Height;
                    else
                    GameObjectManager.Instance.GameObjectList.Remove(fireball);
                        break;
                    case Direction.Right:
                    if (block.BlockState is UnbreakableBlockState)
                        fireball.Position += Vector2.UnitX * intersection.Height;
                    else
                        GameObjectManager.Instance.GameObjectList.Remove(fireball);
                        break;
                }
        }
        public void IsOnLand(IProjectile fireball)
        {
            if (result==Direction.Left || result==Direction.Right || result==Direction.Up)
            {
                fireball.IsLandTrue();
            }
            else if (result==Direction.None)
            {
                fireball.IsLandFalse();
            }
        }
    }
    
}
