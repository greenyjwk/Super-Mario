using Mario.Interfaces.CollisionHandlers;

namespace Game1
{
	public interface IProjectileCollisionHandler : ICollisionHandler
    {
        void HandleCollision(IProjectile projectile);
    }
}
