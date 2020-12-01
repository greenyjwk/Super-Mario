using Mario.Enums;
using Microsoft.Xna.Framework;
namespace Game1
{
	public interface IMarioEnemyCollisionHandler
    {
        void HandleCollision(IMario mario, IEnemy enemy, Direction result, Rectangle intersection);
    }
}
