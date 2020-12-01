using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Mario.GameObjects.Decorators
{
	abstract class GameObjectDecorator : IGameObject
	{
		private IGameObject decoratedObject;
        public virtual Rectangle Box { get => decoratedObject.Box; }
		protected IGameObject DecoratedObject { get => decoratedObject; set => decoratedObject = value; }

		protected GameObjectDecorator(IGameObject obj)
		{
			decoratedObject = obj;
		}
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			decoratedObject.Draw(spriteBatch);
		} 

		public virtual void Update()
		{
			decoratedObject.Update();
		}

        public virtual void SetContainsItem(String item)
        { }
    }
}
