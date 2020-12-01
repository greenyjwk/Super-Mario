using Game1;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Microsoft.Xna.Framework;


namespace Mario.BlockStates
{
	class QuestionBlockState : BlockState
    {

        public QuestionBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
        public override void React()
        {
			Block.Position = new Vector2(Block.Position.X, Block.Position.Y - BlockUtil.BlockOffset);
			if (GameObjectManager.Instance.GameObjectList.HasObject(Block))
			{
				GameObjectManager.Instance.GameObjectList.SetGameObject(Block,new BumpedBlockDecorator(Block));
			}

            base.React();
		}
     
    }
}
