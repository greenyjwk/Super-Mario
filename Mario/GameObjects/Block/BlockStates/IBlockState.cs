using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
	public interface IBlockState : IUpdateable
	{
		void React();
		void Draw(SpriteBatch spriteBatch, Vector2 location);
		int GetWidth { get; }
		int GetHeight { get; }
    }
}
