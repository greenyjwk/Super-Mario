using Game1;
using Mario.Factory;

namespace Mario.BlockStates
{
	class FloorBlockState : BlockState
    {
        public FloorBlockState(IBlock block) : base(block)
        {

			BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
       
    }
}
