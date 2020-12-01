using Game1;
using Mario.AbstractClass;
using Microsoft.Xna.Framework;

namespace Mario.EnemyStates.GoombaStates
{
	public class LeftMovingKoopaState : EnemyState
    {
        public LeftMovingKoopaState(IEnemy enemy) : base(enemy)
        {
        }
        public override void TurnRight()
        {
            Enemy.EnemyState = new RightMovingKoopaState(Enemy);
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
            Enemy.Position -= Vector2.UnitX;
        }
    }
}
