using Mario.Classes.BlocksClasses;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.ItemClasses
{
	public class OneUpMushroom : Item
    {
        public OneUpMushroom(Vector2 location) : base(location)
        {
            SoundManager.Instance.PlaySoundEffect("powerUpAppears");
        }
    }
}
