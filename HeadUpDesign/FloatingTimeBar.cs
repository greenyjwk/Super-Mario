using Mario.Factory;
using Mario.Interfaces.GameObjects;
using Mario.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.HeadUpDesign
{
	static class FloatingTimeBar
    {
      
        public static void CreateNewTimeAnimation(IGameObject gameObject, int timeToDisplay)
        {
            Rectangle objectBox = gameObject.Box;
            Vector2 location = new Vector2(objectBox.X, objectBox.Y);
            ITextSprite timeTextSprite;
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.Text = "+" + timeToDisplay + "s";
            timeTextSprite.IsFlying = true;
            timeTextSprite.Location = location;
            timeTextSprite.InitialY = (int)location.Y;
            GameObjectManager.Instance.UIScoreSprite.Add(timeTextSprite);
        }
        public static void Update()
        {
            foreach (ITextSprite TextBars in GameObjectManager.Instance.UIScoreSprite)
            {
                int difference = TextBars.InitialY - (int)TextBars.Location.Y;
                if (TextBars.IsFlying && difference < ScoreUtil.FlyingBar*HUDUtil.Double)
                {
                    TextBars.Location = new Vector2(TextBars.Location.X, TextBars.Location.Y -HUDUtil.floatRate);
                }
                else
                 {
                    TextBars.IsFlying = false;
                 }
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (ITextSprite TextBars in GameObjectManager.Instance.UIScoreSprite)
            if (TextBars.IsFlying)
            {
                TextBars.Draw(spriteBatch);
            }
        }
    }
}
