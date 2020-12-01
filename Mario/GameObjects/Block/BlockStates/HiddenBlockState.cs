using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;


namespace Mario.BlockStates
{
	class HiddenBlockState : BlockState
    {
        public HiddenBlockState(IBlock block) : base(block)
        {
            BlockSprite = SpriteFactory.Instance.CreateEmptySprite(BlockUtil.HiddenEmptySprite, BlockUtil.HiddenEmptySprite);
        }
        public override void React()
        {
            base.React();
            Block.BlockState = new DisappearBlockState(Block);
            GameObjectManager.Instance.GameObjectList.Add(BlockFactory.Instance.GetGameObject(typeof(UsedBlockState), new Vector2(Block.Position.X, Block.Position.Y)));
        }
   
    }
}
