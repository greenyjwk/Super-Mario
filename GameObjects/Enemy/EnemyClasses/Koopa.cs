using Mario.AbstractClass;
using Mario.EnemyStates.GoombaStates;
using Microsoft.Xna.Framework;

namespace Mario.EnemyClasses
{

	public class Koopa : Enemy
    {

		public Koopa(Vector2 location) : base(location)
		{
			EnemyState = new LeftMovingKoopaState(this);
		}
    }
}
