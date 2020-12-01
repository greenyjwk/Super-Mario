using Game1;
using Mario.Factory;

namespace Mario.BlockStates
{
	class PipeState : BlockState
    {
        public PipeState(IBlock pipe) : base(pipe)
        {

			BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[GetType()]);
		}


    }
}
