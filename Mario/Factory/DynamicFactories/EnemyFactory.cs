using Game1;
using Mario.EnemyClasses;
using Mario.EnemyStates.GoombaStates;
using Mario.GameObjects;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	class EnemyFactory : DynamicGameObjectFactory
	{
		private static readonly EnemyFactory instance = new EnemyFactory();
		public static EnemyFactory Instance { get => instance; }
		private EnemyFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{typeof(Goomba), GetGoomba },
				{typeof(Koopa),GetKoopa },
                {typeof(MiniBoss),GetMiniBoss}
			};
		}
        private IGameObject GetMiniBoss(Vector2 position)
        {
            return new MiniBoss(position);
        }
		private IGameObject GetGoomba(Vector2 position)
		{
			return new Goomba(position);
		}

		private IGameObject GetKoopa(Vector2 position)
		{
			return new Koopa(position);
		}

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Dictionary<Type, Tuple<Texture2D,int,int>>>
			{
                {typeof(Koopa), new Dictionary<Type, Tuple<Texture2D,int,int>>{
                        {typeof(StompedKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.StompedKoopa),1,1) },
                        {typeof(LeftStompedKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.StompedKoopa),1,1) },
                        {typeof(RightStompedKoopaState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.StompedKoopa),1,1) },
                        {typeof(FlippedKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.FlippedKoopa),1,1) },
                        {typeof(LeftMovingKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.LeftMovingKoopa),1,2) },
                        {typeof(RightMovingKoopaState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.RightMovingKoopa),1,2) }
                    }
                },

                {typeof(Goomba), new Dictionary<Type, Tuple<Texture2D,int,int>>{
                        {typeof(StompedGoombaState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.StompedGoomba),1,1 )},
                        {typeof(FlippedGoombaState), new Tuple<Texture2D, int, int>( content.Load<Texture2D>(SpriteString.FlippedGoomba),1,2 )},
                        {typeof(RightMovingGoombaState), new Tuple<Texture2D, int, int>( content.Load<Texture2D>(SpriteString.MovingGoomba),1,2) },
                        { typeof(LeftMovingGoombaState), new Tuple<Texture2D, int, int>( content.Load<Texture2D>(SpriteString.MovingGoomba),1,2)}
                    }
                },

                {typeof(MiniBoss), new Dictionary<Type, Tuple<Texture2D,int,int>>{
                        {typeof(StompedMiniBossState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.MiniBossStomped),1,2 )},
                        {typeof(LeftMiniBossState), new Tuple<Texture2D, int, int>(content.Load<Texture2D>(SpriteString.MiniBossActive),1,4 )}


                    }
                }
            };
		}
	}
}
