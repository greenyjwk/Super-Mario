using Game1;
using Mario.Factory;
using Mario.Sound;

namespace Mario.BlockStates
{
	public class DisappearBlockState : BlockState
    {
        public DisappearBlockState(IBlock block) : base(block)
        {
            BlockSprite = SpriteFactory.Instance.CreateEmptySprite(BlockUtil.emptySprite, BlockUtil.emptySprite);
			SoundManager.Instance.PlaySoundEffect("bump");
        }


    }
}
