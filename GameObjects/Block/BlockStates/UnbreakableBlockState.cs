using Game1;
using Mario.Factory;

namespace Mario.BlockStates
{
	class UnbreakableBlockState : BlockState
    {
        public UnbreakableBlockState(IBlock block) : base(block)
        {

			BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[GetType()]);
		}

    }
}
