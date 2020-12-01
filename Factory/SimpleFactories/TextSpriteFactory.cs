using Mario.Sprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites;

namespace Mario.Factory
{
	class TextSpriteFactory
    {
        private SpriteFont normalFont;

        private static readonly TextSpriteFactory instance = new TextSpriteFactory();

        public static TextSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private TextSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            normalFont = content.Load<SpriteFont>("TextSpriteForHUD");

        }

        public ITextSprite CreateNormalFontTextSpriteSprite()
        {
            return new TextSprite(normalFont);
        }
     

    }
}