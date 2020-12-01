using Game1;
using Mario.AbstractClass;

namespace Mario.EnemyStates.GoombaStates
{
	public class StompedKoopaState : EnemyState
    {
        public StompedKoopaState(IEnemy enemy) : base(enemy)
        {
            Enemy = enemy;
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedKoopaState(Enemy);
        }

        public override bool IsKoopa()
        {
            return true;
        }
        public override bool IsKoopaStomped()
        {
            return true;
        }
        public override void TurnLeft()
        {
            Enemy.EnemyState = new LeftStompedKoopaState(Enemy);
        }
        public override void TurnRight()
        {
            Enemy.EnemyState = new RightStompedKoopaState(Enemy);
        }


    }
}
