using Game1;
using Microsoft.Xna.Framework;
using System;

namespace Mario.GameObjects.Decorators
{
	class BlockDecorator:GameObjectDecorator, IBlock
	{
		public BlockDecorator(IBlock decoratedBlock):base(decoratedBlock)
		{
			DecoratedBlock = decoratedBlock;
		}

		public IBlock DecoratedBlock { get => (IBlock)DecoratedObject; set => DecoratedObject = value; }
        
        public Vector2 Position { get => DecoratedBlock.Position; set => DecoratedBlock.Position = value; }
		public IBlockState BlockState { get => DecoratedBlock.BlockState; set => DecoratedBlock.BlockState = value; }
        public string ItemContained { get => DecoratedBlock.ItemContained; set => DecoratedBlock.ItemContained = value; }
        public bool ToUnderground { get; set; }

        public override void SetContainsItem(String item)
        {
        }
        public void React()
		{
			DecoratedBlock.React();
        }

        public void SetToUnderground(string flag)
        {
            
        }
    }
}
