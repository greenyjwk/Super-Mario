using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
   public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch,Vector2 location);
		int Width { get; }

		int Height { get; }

		void Draw(SpriteBatch spriteBatch, Vector2 position, Color pink);
	}
}
