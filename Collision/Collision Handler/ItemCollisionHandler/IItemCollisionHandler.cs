using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
	public interface IItemCollisionHandler: ICollisionHandler
    {
        void HandleCollision(IItem item);
    }
}
