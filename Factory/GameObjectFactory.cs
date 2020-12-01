using Mario.Interfaces;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	public abstract class GameObjectFactory : IGameObjectFactory, IContentBehavior
	{
		private Dictionary<Type, Func<Vector2, IGameObject>> instantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>();
		protected Dictionary<Type,Func<Vector2,IGameObject>> InstantiationLedger { get => instantiationLedger; set => instantiationLedger = value; }
		public IGameObject GetGameObject(Type type, Vector2 position)
		{
            return GetInstantiatorByTypeName(type)(position);
		}

		public Func<Vector2, IGameObject> GetInstantiatorByTypeName(Type type)
		{
			return instantiationLedger[type];
		}

		public abstract void LoadContent(ContentManager content);
	}
}
