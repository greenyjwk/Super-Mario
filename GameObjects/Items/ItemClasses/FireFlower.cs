using Mario.Classes.BlocksClasses;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.ItemClasses
{
	public class FireFlower :Item 
    {
        public FireFlower(Vector2 location) : base(location)
        {
			SoundManager.Instance.PlaySoundEffect("powerUpAppears");
        }
        public override void Update()
        {
            ItemSprite.Update();
            gravityManagement.Update();

        }
    }
}
