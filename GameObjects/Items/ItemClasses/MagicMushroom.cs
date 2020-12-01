using Mario.Classes.BlocksClasses;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.ItemClasses
{
	public class MagicMushroom : Item
    {
        public MagicMushroom(Vector2 location) : base(location)
        {
			SoundManager.Instance.PlaySoundEffect("powerUpAppears");
        }
    }
}
