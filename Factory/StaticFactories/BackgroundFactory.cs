using Game1;
using Mario.Classes.BackgroundClasses;
using Mario.Classes.BlocksClasses;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	class BackgroundFactory : StaticGameObjectFactory
	{
		private static readonly BackgroundFactory instance = new BackgroundFactory();
		public static BackgroundFactory Instance { get => instance;  }
		
		public BackgroundFactory()
		{

		}

		public IGameObject GetBackgroundObject(string backgroundObjectName, Vector2 arg)
		{
			Background backgroundObj = new BackgroundObject(arg)
			{
				BackgroundSprite = SpriteFactory.Instance.CreateSprite(GameObjectSprites[backgroundObjectName])
			};
			return backgroundObj;
		}
		public override void LoadContent(ContentManager content)
		{
			GameObjectSprites = new Dictionary<string, Tuple<Texture2D,int,int>>
			{
				{"BushSingle", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SingleBush),1,1) },
				{"BushTriple", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.TripleBush),1,1) },
				{"CloudSingle", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SingleCloud),1,1) },
				{"CloudTriple",new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.TripleCloud),1,1) },
				{"MountainBig", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.BigMountain),1,1) },
                {"BlackGround", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.BlackGround),1,1) },
                {"MountainSmall", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.SmallMountain),1,1) },
                {"Castle", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.Castle),1,1) },
                {"Flag", new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.Flag),1,5) }
            };
		}
	}
}
