using Mario.Classes.BlocksClasses;
using Microsoft.Xna.Framework;

namespace Mario.ItemClasses
{
	public class BrickParticleLeft : Item
    {
        public BrickParticleLeft(Vector2 location):base(location)
        {
        }
      
        public override void Update()
        {
            ItemSprite.Update();
            gravityManagement.Update();
            Position -= Vector2.UnitX * 5;
        }

    }
}
