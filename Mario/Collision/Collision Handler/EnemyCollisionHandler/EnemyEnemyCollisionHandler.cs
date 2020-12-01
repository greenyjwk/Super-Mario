using Game1;
using Mario.EnemyStates.GoombaStates;
using Mario.Enums;
using Mario.HeadUpDesign;
using Microsoft.Xna.Framework;

namespace Mario.Collision.EnemyCollisionHandler
{
	public class EnemyEnemyCollisionHandler : IEnemyCollisionHandler
    {
        Rectangle intersection;
        IEnemy enemy;
        Direction result;
        public EnemyEnemyCollisionHandler(IEnemy enemy, Rectangle intersection, Direction result)
        {
            this.intersection = intersection;
            this.enemy = enemy;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemyParam)
        {
                GoombaKoopaReact(enemyParam);
            if (!(enemy.EnemyState is StompedGoombaState))
            {
                CollisionCondition(enemyParam);
            }

        }
        private void GoombaKoopaReact(IEnemy enemyParam)
        {
            if (enemyParam.EnemyState is LeftStompedKoopaState&& result==Direction.Right
                || enemyParam.EnemyState is RightStompedKoopaState && result==Direction.Left)
            {
                enemy.Beflipped();
                Timer.ExtendTime(TimerUtil.Two);
                FloatingTimeBar.CreateNewTimeAnimation(enemyParam, TimerUtil.Three* TimerUtil.ExtentTime);
                ScoringSystem.Instance.AddPointsForEnemyHitByShell(enemyParam);
            }
        }
        private void NonStompedKoopaReact(IEnemy enemyParam)
        {
            if (!(enemyParam.EnemyState is StompedKoopaState)
                && !(enemyParam.EnemyState is RightStompedKoopaState) 
                && result==Direction.Left)
            {
                enemyParam.Position -= Vector2.UnitX * intersection.Width;
                enemyParam.TurnLeft();
            }
            if (!(enemyParam.EnemyState is StompedKoopaState) && !(enemyParam.EnemyState is LeftStompedKoopaState) && result==Direction.Right)
            {
                enemyParam.Position += Vector2.UnitX * intersection.Width;
                enemyParam.TurnRight();
            }
        }
        private void CollisionCondition(IEnemy enemyParam)
        {
            switch (result)
            {
                case Direction.Up:
                    enemyParam.Position -= Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Down:
                    enemyParam.IsLandTrue();
                    enemyParam.Position += Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Left:
                    NonStompedKoopaReact(enemyParam);
                    enemy.TurnRight();
                    break;
                case Direction.Right:
                    NonStompedKoopaReact(enemyParam);
                    enemy.TurnLeft();
                    break;
                case Direction.None:
                    enemyParam.IsLandFalse();
                    break;
            }
        }
    }
}
