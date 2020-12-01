using Mario.Enums;
using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
	public interface IBlockCollisionHandler:ICollisionHandler
    {
        void HandleCollision(IBlock block,IMario mario ,Direction result);
    }
}
