using Game1;
using Mario.BlockStates;
using Mario.Enums;
using Mario.GameObjects;
using Mario.GameObjects.Decorators;
using Mario.HeadUpDesign;
using Microsoft.Xna.Framework;

namespace Mario.Collision.EnemyCollisionHandler
{
	public class EnemyBlockCollisionHandler : IEnemyCollisionHandler
    {
		readonly IBlock block;
        Rectangle intersection;
        Direction result;
		public EnemyBlockCollisionHandler(IBlock block,Rectangle intersection, Direction result)
        {
            this.block = block;
            this.intersection = intersection;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemy)
        {
            IsOnLand(enemy);
            if (!(block.BlockState is HiddenBlockState))
            {
                PositionAdjustment(enemy);
            }
           
        }
        public void EnemyBumpedBlockReact(IEnemy enemy)
        {
            if (block is BumpedBlockDecorator)
            {
                enemy.Beflipped();
                ScoringSystem.Instance.AddPointsForEnemyBelowBlockHit(enemy);
            }
        }
        public void IsOnLand(IEnemy enemy)
        {
            if(result==Direction.Up)
            {
                enemy.IsLandTrue();
            }
            else if(result==Direction.None)
            {
                enemy.IsLandFalse();
            }
        }
        public void PositionAdjustment(IEnemy enemy)
        {
            switch (result)
            {
                case Direction.Up:
                    enemy.Position -= Vector2.UnitY * intersection.Height;
                    
                    EnemyBumpedBlockReact(enemy);
                    break;
                case Direction.Down:
                    enemy.Position += Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Left:
                    enemy.Position -= Vector2.UnitX * intersection.Width;
                    enemy.TurnLeft();
                    break;
                case Direction.Right:
                    enemy.Position += Vector2.UnitX * intersection.Width;
                    enemy.TurnRight();
                    break;
            }

        }

    }

}
