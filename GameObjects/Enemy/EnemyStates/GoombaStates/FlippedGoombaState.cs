using Game1;
using Mario.AbstractClass;

namespace Mario.EnemyStates.GoombaStates
{
	public class FlippedGoombaState : EnemyState
    {
        public FlippedGoombaState(IEnemy enemy) :base(enemy)
        {
        }
        public override bool IsFlipped()
        {
            return true;
        }
        public override void Update()
        {
            Enemy.gravityManagement.Update();
        }
    }
}
