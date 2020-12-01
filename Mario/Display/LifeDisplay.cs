using Game1;
using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Display
{
	public class LifeDisplay : IDisplay
    {
        ISprite marioSprite;
        IGameObject backgroundObject;
        ITextSprite lifeTextSprite;
      
        private int counter;
        public LifeDisplay()
        {
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            if (GameObjectManager.Instance.LifeDisplayTrigger)
            {
                lifeTextSprite.Text = " X ";
                lifeTextSprite.Text += LifeCounter.Instance.LifeRemains().ToString();

            }
            else
            {
                lifeTextSprite.Text = " L o a d i n g ";
            }
            
            counter = SpriteUtil.Zero;
            backgroundObject = BackgroundFactory.Instance.GetBackgroundObject("BlackGround", new Vector2(SpriteUtil.Zero, SpriteUtil.Zero));
            marioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[typeof(NormalMarioPowerupState)][typeof(RightIdleMarioMovementState)]);
        }
        public void Update()
        {
            counter++;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (counter < TimerUtil.DisplayTimer)
            {
                backgroundObject.Draw(spriteBatch);
                lifeTextSprite.Location = new Vector2(SpriteUtil.textPositionX, SpriteUtil.textPositionY);
                lifeTextSprite.Draw(spriteBatch);
                marioSprite.Draw(spriteBatch, new Vector2(SpriteUtil.marioPositionX, SpriteUtil.marioPositionY));
            }
            
        }
    }
}
