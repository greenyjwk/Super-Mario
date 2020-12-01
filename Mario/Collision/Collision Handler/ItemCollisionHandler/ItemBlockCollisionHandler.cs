using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.Enums;
using Mario.ItemClasses;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.Collision.ItemCollisionHandler
{
	class ItemBlockCollisionHandler : IItemCollisionHandler
    {
        Rectangle intersection;
        IBlock block;
        Direction result;
        public  ItemBlockCollisionHandler(IBlock block, Rectangle intersection, Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IItem item)
        {
            if (!(item is Coin)&&!(item is BrickParticleLeft)&&!(item is BrickParticleRight))
            switch (result)
            {
                case Direction.Up:
                    item.Position -= Vector2.UnitY* intersection.Height;
                    item.IsLandTrue();
                    break;
                case Direction.Down:
                    item.Position += Vector2.UnitY* intersection.Height;
						SoundManager.Instance.PlaySoundEffect(SoundString.marioCoin);
                    break;
                case Direction.Left:
                    item.Position -= Vector2.UnitX*intersection.Width;
                        ItemTurnLeft(item);
                    break;
                case Direction.Right:
                    item.Position += Vector2.UnitX*intersection.Width;
                        ItemTurnRight(item);
                    break;
                case Direction.None:
                    item.IsLandFalse();
                    break;
            }
        }
        public void ItemTurnLeft(IItem item)
        {
            if(block is Pipe||block.BlockState is UnbreakableBlockState)
            {
                item.TurnLeft();
            }
        }
        public void ItemTurnRight(IItem item)
        {
            if (block is Pipe|| block.BlockState is UnbreakableBlockState)
            {
                item.TurnRight();
            }
        }
    }
}
