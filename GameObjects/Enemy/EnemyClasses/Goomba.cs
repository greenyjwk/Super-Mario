using Mario.AbstractClass;
using Mario.EnemyStates.GoombaStates;
using Microsoft.Xna.Framework;

namespace Mario.EnemyClasses
{
	public class Goomba : Enemy
    {

        public Goomba(Vector2 location) : base(location)
        {
            EnemyState = new LeftMovingGoombaState(this);
			Velocity = -Vector2.UnitX;
        
        }
       


    }
}
