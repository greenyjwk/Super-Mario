
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.GameObjects.Decorators
{
	abstract class MarioSpecialEventDecorator : MarioDecorator
	{
		protected MarioSpecialEventDecorator(IMario mario) : base(mario)
		{
		}

		public override Rectangle Box => base.Box;

		public override void TakeDamage()
		{
			//NO-OP
		}

		public override void Update()
		{

		}

		public virtual void RemoveSelf()
		{
			GameObjectManager.Instance.GameObjectList.SetSingleton(typeof(IMario), this.DecoratedMario);
		}

		public override void NoInput()
		{

		}
		public override void GoLeft()
		{
			
		}
		public override void GoRight()
		{
			
		}

		public override void GoUp()
		{
			
		}
	}
}
