using Mario.Interfaces.CollisionHandlers;
namespace Game1
{
	public interface IEnemyCollisionHandler :ICollisionHandler
    {
        void HandleCollision(IEnemy enemy);
    }
}
