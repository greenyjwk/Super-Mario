using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;

namespace Mario.EnemyStates.GoombaStates
{
	public class RightMovingKoopaState : EnemyState
    {
        public RightMovingKoopaState(IEnemy enemy):base(enemy)
        {
        }
        public override void TurnLeft()
        {
            Enemy.EnemyState = new LeftMovingKoopaState(Enemy);

        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedKoopaState(Enemy);
        }
        public override void BeStomped()
        {
            Enemy.EnemyState = new StompedKoopaState(Enemy);
        }
        
        public override bool IsKoopa()
        {
            return true;
        }
        public override void Update()
        {
            EnemySprite.Update();
           
                Enemy.gravityManagement.Update();
            Enemy.Position += Vector2.UnitX;
        }

    }
}
