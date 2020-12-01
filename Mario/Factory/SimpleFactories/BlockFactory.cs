using Game1;
using Mario.BlocksClasses;
using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Mario.Factory
{
	class BlockFactory : SimpleGameObjectFactory
	{
		private static BlockFactory instance = new BlockFactory();

		public static BlockFactory Instance { get => instance; }
		
		public BlockFactory()
		{
			InstantiationLedger = new Dictionary<Type, Func<Vector2, IGameObject>>
			{
				{typeof( HiddenBlockState ), GetHiddenBlock  },
				{typeof( FloorBlockState), GetFloorBlock },
				{typeof( Pipe ), GetPipe },
				{typeof( QuestionBlockState ), GetQuestionBlock },
				{typeof( UnbreakableBlockState ),GetUnbreakableBlock },
                {typeof( UsedBlockState ),GetUsedBlock },
				{typeof( BrickBlockState), GetBrickBlock }


			};
		}

		private IGameObject GetBrickBlock(Vector2 arg)
		{
			IBlock retBlock = new BlockWithContainer(arg);
			retBlock.BlockState = new BrickBlockState(retBlock);
			return retBlock;
		}

		private IGameObject GetUnbreakableBlock(Vector2 arg)
		{
			IBlock retBlock = new BlockWithContainer(arg);
			retBlock.BlockState = new UnbreakableBlockState(retBlock);
			return retBlock;
		}

		private IGameObject GetQuestionBlock(Vector2 arg)
		{
			IBlock retBlock = new BlockWithContainer(arg);
			retBlock.BlockState = new QuestionBlockState(retBlock);
			return retBlock;
		}

		private IGameObject GetPipe(Vector2 arg)
		{
			return new Pipe(arg);
		}


		private IGameObject GetFloorBlock(Vector2 arg)
		{
			IBlock retBlock = new BlockWithContainer(arg);
			retBlock.BlockState = new FloorBlockState(retBlock);
			return retBlock;
		}

		private IGameObject GetHiddenBlock(Vector2 arg)
		{
			IBlock retBlock = new BlockWithContainer(arg);
			retBlock.BlockState = new HiddenBlockState(retBlock);
			return retBlock;
		}
        private IGameObject GetUsedBlock(Vector2 arg)
        {
			IBlock retBlock = new BlockWithContainer(arg);
			retBlock.BlockState = new UsedBlockState(retBlock);
            return retBlock;
        }

		public override void LoadContent(ContentManager content)
		{
			SpriteDictionary = new Dictionary<Type, Tuple<Texture2D,int,int>>
			{
                {typeof(PipeState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.Pipe),1,1) },
                {typeof(BrickBlockState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.BrickBlock),1,1)},
				{typeof(FloorBlockState), new Tuple<Texture2D,int,int>( content.Load<Texture2D>(SpriteString.FloorBlock),1,1) },
				{typeof(HiddenBlockState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.UsedBlock),1,1) },
				{typeof(QuestionBlockState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.QuestionBlock),1,3) },
				{typeof(UnbreakableBlockState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.UnbreakableBlock),1,1) },
				{typeof(UsedBlockState), new Tuple<Texture2D,int,int>(content.Load<Texture2D>(SpriteString.UsedBlock),1,1) }

            };
		}
	}
}
