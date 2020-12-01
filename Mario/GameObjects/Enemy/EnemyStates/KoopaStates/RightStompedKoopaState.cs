using Game1;
using Mario.AbstractClass;
using Mario.EnemyClasses;
using Mario.Factory;

namespace Mario.EnemyStates.GoombaStates
{
	public class RightStompedKoopaState : EnemyState
    {
        public RightStompedKoopaState(IEnemy enemy):base(enemy)
        {
            Enemy = enemy;
            EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[typeof(Koopa)][typeof(StompedKoopaState)]);
        }
        public override bool IsRightStomped()
        {
            return true;
        }
        public override void Beflipped()
        {
            Enemy.EnemyState = new FlippedKoopaState(Enemy);
        }
       
        public override bool IsKoopa()
        {
            return true;
        }
        public override void TurnLeft()
        {
            Enemy.EnemyState = new LeftStompedKoopaState(Enemy);
        }
        public override void Update()
        {
            EnemySprite.Update();
           
                Enemy.gravityManagement.Update();
                Enemy.Position += EnemyUtil.Util;
        }


    }
}
