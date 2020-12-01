using Game1;
using Mario.EnemyStates.GoombaStates;
using Mario.Enums;
using Mario.HeadUpDesign;
using Mario.Sound;

namespace Mario.Collision.EnemyCollisionHandler
{
	public class EnemyMarioCollisionHandler: IEnemyCollisionHandler
    {
        IMario mario;
        Direction result;
        public EnemyMarioCollisionHandler(IMario mario, Direction result)
        {
            this.mario = mario;
            this.result = result;
        }
        public void HandleCollision(IEnemy enemy)
        {
            if (mario.IsStarMario()&&result!=Direction.None)
            {
                enemy.Beflipped();
                SoundManager.Instance.PlaySoundEffect(SoundString.flip);
                ScoringSystem.Instance.AddPointsForStompingEnemy(enemy);
            }

         
            if (result==Direction.Up)
            {
                enemy.BeStomped();
                SoundManager.Instance.PlaySoundEffect(SoundString.stomp);

            }
            
            if (enemy.EnemyState is StompedKoopaState && result==Direction.Right)
            {
                enemy.TurnLeft();
				SoundManager.Instance.PlaySoundEffect(SoundString.flip);
            }
            else if(enemy.EnemyState is StompedKoopaState && result==Direction.Left)
            {
                enemy.TurnRight();
				SoundManager.Instance.PlaySoundEffect(SoundString.flip);
            }

        }
     
	}
}
