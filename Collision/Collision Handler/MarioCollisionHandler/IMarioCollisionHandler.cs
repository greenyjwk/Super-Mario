using Mario.Enums;
namespace Game1
{
	public interface IMarioCollisionHandler
    {
        void HandleCollision(IMario mario, Direction result);
    }
}
