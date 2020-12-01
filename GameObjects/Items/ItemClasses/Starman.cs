using Mario.Classes.BlocksClasses;
using Microsoft.Xna.Framework;

namespace Mario.ItemClasses
{
	public class Starman : Item
    {
        public Starman(Vector2 location) : base(location)
        {
        }
        public override bool IsStarman()
        {
            return true;
        }
        public override void IsLandTrue()
        {
            Island = true;
            gravityManagement.ReverseYVelocity();
        }
    }


}
