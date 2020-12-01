using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	class ProjectileFactory : SimpleGameObjectFactory
	{
		private static ProjectileFactory instance = new ProjectileFactory();
		public static ProjectileFactory Instance { get => instance; }
		
		private ProjectileFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
                {typeof(Fireball),GetFireball }
			};
		}

		
        private IGameObject GetFireball(Vector2 arg)
        {
            return new Fireball(arg);
        }

        public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Tuple<Texture2D,int,int>>
			{
                {typeof(Fireball), new Tuple<Texture2D, int, int>(content.Load<Texture2D>("Fireball"),1,4) }
            };
		}
	}
}
