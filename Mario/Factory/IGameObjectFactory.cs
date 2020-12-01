using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using System;

namespace Mario.Factory
{
	public interface IGameObjectFactory
	{
		IGameObject GetGameObject(Type typeName, Vector2 position);
		Func<Vector2, IGameObject> GetInstantiatorByTypeName(Type typeName);

	}
}
