using Game1;
using Mario.Interfaces.GameObjects;
using Mario.ItemClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	class ItemFactory:SimpleGameObjectFactory
	{
		private static ItemFactory instance = new ItemFactory();
		public static ItemFactory Instance { get => instance; }
		
		private ItemFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{typeof(Coin),GetCoin },
                {typeof(UnderGroundCoin),GetUnderGroundCoin },
                {typeof(FireFlower),GetFireFlower },
				{typeof(MagicMushroom),GetMagicMushroom },
				{typeof(OneUpMushroom),GetOneUpMushroom },
				{typeof(Starman), GetStarman },
                {typeof(BrickParticleLeft), GetBrickParticleLeft },
                {typeof(BrickParticleRight), GetBrickParticleRight },

            };
		}

		private IGameObject GetStarman(Vector2 arg)
		{
			return new Starman(arg);
		}

		private IGameObject GetOneUpMushroom(Vector2 arg)
		{
			return new OneUpMushroom(arg);
		}

		private IGameObject GetMagicMushroom(Vector2 arg)
		{
			return new MagicMushroom(arg);
		}

		private IGameObject GetFireFlower(Vector2 arg)
		{
			return new FireFlower(arg);
		}

		private IGameObject GetCoin(Vector2 arg)
		{
			return new Coin(arg);
		}
        private IGameObject GetUnderGroundCoin(Vector2 arg)
        {
            return new UnderGroundCoin(arg);
        }
        private IGameObject GetBrickParticleLeft(Vector2 arg)
        {
            return new BrickParticleLeft(arg);
        }
        private IGameObject GetBrickParticleRight(Vector2 arg)
        {
            return new BrickParticleRight(arg);
        }

        public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Tuple<Texture2D, int, int>>
			{
				{typeof(Coin), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.Coin),1,4) },
                {typeof(UnderGroundCoin), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.Coin),1,4) },
                {typeof(FireFlower),new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.FireFlower),1,4)},
				{typeof(MagicMushroom), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.MagicMushroom),1,1) },
				{typeof(OneUpMushroom),new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.OneUpMushroom),1,1) },
				{typeof(Starman), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.Starman),1,4) },
                {typeof(BrickParticleRight), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.BreakBrickBlock),1,1) },
                {typeof(BrickParticleLeft), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.BreakBrickBlock),1,1) }


            };
		}
	}
}
