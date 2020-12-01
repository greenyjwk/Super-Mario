using Mario.AbstractClass;
using Mario.EnemyClasses;
using Mario.EnemyStates.GoombaStates;
using Microsoft.Xna.Framework;

namespace Mario.GameObjects
{


    public class MiniBoss : Enemy
    {
		private int health = EnemyUtil.miniBossLife;
        public MiniBoss(Vector2 location) : base(location)
        {

            EnemyState = new LeftMiniBossState(this);
        }
        
        public override void Update()
        {
            EnemyState.Update();
        }
        public override void IsLandTrue()
        {
            Island = true;
            gravityManagement.ReverseYVelocity();
        }
        public override void Beflipped()
        {
            health--;
            if(health==EnemyUtil.miniBossZeroLife)
            EnemyState.Beflipped();
           
        }
       

    }
}