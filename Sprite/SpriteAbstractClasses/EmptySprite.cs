using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.AbstractClass.SpriteAbstractClasses
{
	class EmptySprite : ISprite
	{
		private int width;
		public int Width => width;

		private int height;
		public int Height => height;

		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			//NO OP for sprite w/o texture
		}

		public void Update()
		{
			//NO-OP a null spriteoesn't need to update
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 position, Color pink)
		{
			throw new NotImplementedException();
		}

		public EmptySprite(int width, int height)
		{
			
			this.width = width;
			this.height = height;
		}

		public EmptySprite()
		{
		}
	}
}
