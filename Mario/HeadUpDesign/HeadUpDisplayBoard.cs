using Game1;
using Mario.Factory;
using Mario.ItemClasses;
using Mario.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.HeadUpDesign
{
	class HeadsUpDisplayBoard
    {
        ITextSprite marioTitleTextSprite;
        ITextSprite scoreTextSprite;
        ITextSprite coinTextSprite;
        ITextSprite worldTitleTextSprite;
        ITextSprite worldTextSprite;
        ITextSprite timeTitleTextSprite;
        ITextSprite timeTextSprite;

        public HeadsUpDisplayBoard()
        {


            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.Text = "MARIO";
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.Text = fixText("" + 0, HUDUtil.scoreLength);
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.Text = "*" + fixText("" + 0, HUDUtil.coinLength);
            worldTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTitleTextSprite.Text = "WORLD";
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.Text = fixText("1 - " + LevelCounter.Instance.Level, HUDUtil.levelLength);
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.Text = "TIME";
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.Text = fixText("" + Timer.Time, HUDUtil.timeLength);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int marioTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (HUDUtil.offset * HUDUtil.Double /HUDUtil.five);
            marioTitleTextSprite.Location = new Vector2(marioTitleTextX, HUDUtil.distance);
            marioTitleTextSprite.Draw(spriteBatch);

            int scoreTextX = marioTitleTextX;
            scoreTextSprite.Location = new Vector2(scoreTextX, HUDUtil.distanceOfSecRowText);
            scoreTextSprite.Draw(spriteBatch);

            int coinTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (HUDUtil.offset * HUDUtil.Double / HUDUtil.five) + HUDUtil.distanceOfSecRowText*6;
            coinTextSprite.Location = new Vector2(coinTextX, HUDUtil.distanceOfSecRowText);


            ISprite CoinSprite = SpriteFactory.Instance.CreateSprite(ItemFactory.Instance.GetSpriteDictionary[typeof(Coin)]);
            coinTextSprite.Draw(spriteBatch);
            Vector2 coinSpriteLocation = new Vector2(coinTextSprite.Location.X - HUDUtil.textOffset, coinTextSprite.Location.Y);
            CoinSprite.Draw(spriteBatch, coinSpriteLocation);


            int worldTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (HUDUtil.offset * HUDUtil.Double / HUDUtil.five) + HUDUtil.distanceOfSecRowText * HUDUtil.distance;
            worldTitleTextSprite.Location = new Vector2(worldTitleTextX, HUDUtil.distance);
            worldTitleTextSprite.Draw(spriteBatch);

            int worldTextX = worldTitleTextX;
            worldTextSprite.Location = new Vector2(worldTextX, HUDUtil.distanceOfSecRowText);
            worldTextSprite.Draw(spriteBatch);

            int timeTitleTextX = (int)GameObjectManager.Instance.CameraMario.Location.X + (HUDUtil.offset * HUDUtil.Double / HUDUtil.five) + HUDUtil.distanceOfSecRowText * HUDUtil.titleDistance;
            timeTitleTextSprite.Location = new Vector2(timeTitleTextX, HUDUtil.distance);
            timeTitleTextSprite.Draw(spriteBatch);

            int timeTextX = timeTitleTextX;
            timeTextSprite.Location = new Vector2(timeTextX, HUDUtil.distanceOfSecRowText);
            timeTextSprite.Draw(spriteBatch);
        }

        public void Update()
        {
            scoreTextSprite.Text = fixText("" + ScoringSystem.Instance.Score,HUDUtil.scoreLength);
            coinTextSprite.Text = "*" + fixText("" + CoinSystem.Instance.Coins,HUDUtil.coinLength);
            timeTextSprite.Text = fixText("" + Timer.Time,HUDUtil.timeLength);
            worldTextSprite.Text = fixText("1 - " + LevelCounter.Instance.Level, HUDUtil.levelLength);
        }

        private static String fixText(String str, int length)
        {
            while (str.Length < length)
            {
                str = "0" + str;
            }

            return str;
        }

    }

}