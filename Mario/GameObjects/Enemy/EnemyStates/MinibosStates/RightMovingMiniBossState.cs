using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using Microsoft.Xna.Framework;
namespace Mario.EnemyStates.GoombaStates
{
	public class RightMovingMiniBossState : EnemyState
    {
        int delay;
        public RightMovingMiniBossState(IEnemy enemy):base(enemy)
        {
            delay = 0;
        }

      
        public override void Update()
        {
            EnemySprite.Update();
            if (!Enemy.Island)
            {
                Enemy.gravityManagement.Update();
            }
            if (delay == 200)
            {
                GameObjectManager.Instance.GameObjectList.Add(new Goomba(Enemy.Position));
                delay = 0;
            }
            delay++;
        }



    }
}
