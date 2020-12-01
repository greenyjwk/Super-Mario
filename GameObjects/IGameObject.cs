using Game1;

namespace Mario.Interfaces.GameObjects
{
	public interface IGameObject: IDrawable, IUpdateable
	{
        Microsoft.Xna.Framework.Rectangle Box { get; } 
    }
}
