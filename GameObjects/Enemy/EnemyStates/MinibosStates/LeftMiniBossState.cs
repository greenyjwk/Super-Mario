using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using Mario.HeadUpDesign;
using Microsoft.Xna.Framework;
namespace Mario.EnemyStates.GoombaStates
{
	public class LeftMiniBossState : EnemyState
    {
        int delay;
        public LeftMiniBossState(IEnemy enemy):base(enemy)
        {
            delay = EnemyUtil.DelayInitial;
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new StompedMiniBossState(Enemy);
            Timer.ExtendTime(TimerUtil.Ten);
            FloatingTimeBar.CreateNewTimeAnimation(Enemy, TimerUtil.Ten * TimerUtil.ExtentTime);
        }

        public override void Update()
        {
            EnemySprite.Update();
            if (!Enemy.Island)
            {
                Enemy.gravityManagement.Update();
            }

            if (delay == EnemyUtil.DelayRange)
            {
               GameObjectManager.Instance.GameObjectList.Add(new Goomba(Enemy.Position));
                delay = EnemyUtil.DelayInitial;
            }
            delay++;
        }
      



    }
}
