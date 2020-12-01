using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;
namespace Mario.EnemyStates.GoombaStates
{
	public class LeftMovingGoombaState : EnemyState
    {
        public LeftMovingGoombaState(IEnemy enemy):base(enemy)
        {
        }
        public override void BeStomped()
        {
            Enemy.EnemyState = new StompedGoombaState(Enemy);
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedGoombaState(Enemy);
        }
        public override bool IsGoomba()
        {
            return true;
        }
        public override void TurnRight()
        {
            Enemy.EnemyState = new RightMovingGoombaState(Enemy);
        }
        public override void Update()
        {
            EnemySprite.Update();
            if (!Enemy.Island)
            {
                Enemy.gravityManagement.Update();
            }
            Enemy.Position -= Vector2.UnitX;
        }



    }
}
