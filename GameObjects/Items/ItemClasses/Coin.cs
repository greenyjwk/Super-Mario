using Mario.Classes.BlocksClasses;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.ItemClasses
{
	public class Coin : Item
    {
        public Coin(Vector2 location):base(location)
        {
			SoundManager.Instance.PlaySoundEffect("marioCoin");

        }
        public override bool IsCoin()
        {
            return true;
        }
        public override void Update()
        {
            ItemSprite.Update();
           gravityManagement.Update();
         }

    }
}
