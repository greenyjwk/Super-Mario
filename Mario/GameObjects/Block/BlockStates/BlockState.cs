using Game1;
using Mario.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.BlockStates
{
	public abstract class BlockState : IBlockState
    {
        protected ISprite BlockSprite { get; set; }
        protected IBlock Block { get; set; }
        public virtual Rectangle Box { get; }
		
        public int GetWidth
        {
            get
            {
				
                return BlockSprite.Width;
            }
        }
        public int GetHeight
        {
            get
            {
                return BlockSprite.Height;
            }
        }
        protected BlockState(IBlock block)
        {
            this.Block = block;
		}
		public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            BlockSprite.Draw(spriteBatch, location);
        }
        public virtual void Update()
        {
            BlockSprite.Update();
        }

      
        public virtual void React()
        {
			SoundManager.Instance.PlaySoundEffect("bump");
        }
       

       
    }
}
