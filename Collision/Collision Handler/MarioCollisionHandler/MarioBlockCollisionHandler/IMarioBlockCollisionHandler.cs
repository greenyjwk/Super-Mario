using Mario.Enums;
using Microsoft.Xna.Framework;
namespace Game1
{
	public interface IMarioBlockCollisionHandler
    {
        void HandleCollision(IMario mario , Direction result, Rectangle intersection);
    }
}
