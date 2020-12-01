using Game1;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Mario.HeadUpDesign;
using Mario.ItemClasses;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.BlockStates
{
	class BrickBlockState : BlockState
    {
        public BrickBlockState(IBlock block) : base(block)
        {

			this.BlockSprite = SpriteFactory.Instance.CreateSprite(BlockFactory.Instance.GetSpriteDictionary[this.GetType()]);
		}
        public override void React()
        {
            Block.Position -= Vector2.UnitY * BlockUtil.BlockOffset;
            GameObjectManager.Instance.GameObjectList.SetGameObject(Block, new BumpedBlockDecorator(Block));


            if (!(GameObjectManager.Instance.Mario.MarioPowerupState is NormalMarioPowerupState))
            {
                GameObjectManager.Instance.GameObjectList.Remove(Block);
                GameObjectManager.Instance.GameObjectList.Add(new BrickParticleLeft(Block.Position));
                GameObjectManager.Instance.GameObjectList.Add(new BrickParticleLeft(new Vector2(Block.Position.X, Block.Position.Y + BlockUtil.brickBlockParticleOffset)));
                GameObjectManager.Instance.GameObjectList.Add(new BrickParticleRight(new Vector2(Block.Position.X + BlockUtil.brickBlockParticleOffset, Block.Position.Y)));
                GameObjectManager.Instance.GameObjectList.Add(new BrickParticleRight(new Vector2(Block.Position.X + BlockUtil.brickBlockParticleOffset, Block.Position.Y + BlockUtil.brickBlockParticleOffset)));
                ScoringSystem.Instance.AddPointsForBreakingBlock();
				SoundManager.Instance.PlaySoundEffect("breakBlock");
            }
            else {
                base.React();
            }

        }
     
    }
}
