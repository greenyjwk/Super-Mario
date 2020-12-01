using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1;
using Mario.Factory;
using Mario.Enums;
using Mario.Classes.BlocksClasses;

namespace Mario.ItemClasses
{
    public class UnderGroundCoin : Item
    {
        public UnderGroundCoin(Vector2 location):base(location)
        {
            ItemSprite = SpriteFactory.Instance.CreateSprite(ItemFactory.Instance.GetSpriteDictionary[typeof(Coin)]);
        }
      
        public override void Update()
        {
            ItemSprite.Update();
         }

    }
}
