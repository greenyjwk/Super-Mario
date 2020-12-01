using Game1;
using Mario.Factory;


namespace Mario.BlockStates
{
	public class UsedBlockState : BlockState
    {
        public UsedBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[GetType()]);
		}

    }
}
