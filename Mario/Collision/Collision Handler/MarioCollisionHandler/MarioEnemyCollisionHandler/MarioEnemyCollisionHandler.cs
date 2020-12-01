using Game1;
using Mario.EnemyStates.GoombaStates;
using Mario.Enums;
using Mario.HeadUpDesign;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;


namespace Mario.Collision.MarioCollisionHandler.MarioEnemyCollisionHandler
{
	public class MarioEnemyCollisionHandler : IMarioCollisionHandler
    {
        IEnemy enemy;
        Rectangle intersection;
        public MarioEnemyCollisionHandler(IEnemy enemy, Rectangle intersection)
        { 
            this.enemy = enemy;
            this.intersection = intersection;
        }
        public void PositionAdjustment(IMario mario, Direction result)
        {
            switch (result)
            {
                case Direction.Up:
                    mario.Physics.ReverseYVelocity();
                    mario.Position -= Vector2.UnitY* intersection.Height;
                    if (enemy.IsKoopa()&& enemy.KoopaStompedCounted==false)
                    {
                        ScoringSystem.Instance.AddPointsForInitiatingShell(enemy);
                        enemy.KoopaStompedCounted = true;
                    }
                    else if(enemy.IsGoomba())
                    {
                        ScoringSystem.Instance.AddPointsForStompingEnemy(enemy);
                    }
                   
                    break;
                case Direction.Down:
                    mario.Position += Vector2.UnitY * intersection.Height;
                    break;
                case Direction.Left:
                    mario.Position -= Vector2.UnitX * intersection.Width;
                    break;
                case Direction.Right:
                    mario.Position += Vector2.UnitY * intersection.Width;
                    break;
            }
            MarioReact(mario, result);
        }
        public void HandleCollision(IMario mario,Direction result)
        {
            
            if (!(enemy is StompedGoombaState))
            {
                PositionAdjustment(mario, result);
            }
        }
        public void MarioReact(IMario mario,Direction result)
        {
            if ((!(enemy.EnemyState is LeftStompedKoopaState)&&result== Direction.Right)
                || !(enemy.EnemyState is RightStompedKoopaState) && result== Direction.Left
                && !(enemy.IsFlipped())&&!(enemy.EnemyState is StompedGoombaState)&&!(enemy.EnemyState is StompedKoopaState))
            {
                MarioTakeDamage(mario);
            }
            
        }
		public static void  MarioTakeDamage(IMario mario)
        {
			mario.TakeDamage();
         
        }
    }
}
