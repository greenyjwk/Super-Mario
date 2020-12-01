using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using Mario.Factory;

namespace Mario.EnemyStates.GoombaStates
{
	public class FlippedKoopaState : EnemyState
    {
        public FlippedKoopaState(IEnemy enemy) : base(enemy)
        {
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[typeof(Koopa)][typeof(FlippedKoopaState)]);
        }
        
        public override bool IsFlipped()
        {
            return true;
        }
        public override bool IsKoopa()
        {
            return true;
        }
      
    }
}
