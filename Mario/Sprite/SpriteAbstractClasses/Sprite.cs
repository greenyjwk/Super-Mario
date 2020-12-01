using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.AbstractClass.SpriteAbstractClasses
{
	class Sprite : ISprite
	{
		private Texture2D spriteSheet { get; set; }

		private int rows = 1;
		private int columns = 1;

		private int currentFrame = 0;
		private int totalFrame = 0;

		private int delay = 5;
		public int Width
		{
			get
			{
				if (!(spriteSheet == null))
				{
					return spriteSheet.Width/columns;
				}
				else
				{
					return 0;
				}
			}
		}

		public int Height
		{
			get
			{
				if(!(spriteSheet == null))
				{
					return spriteSheet.Height/rows;
				}
				else
				{
					return 0;
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			int row = (int)((float)currentFrame / (float)columns);
			int column = currentFrame % columns;

			Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
			Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

			spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
		}

		public void Update()
		{
			delay++;
			if (delay == 5)
			{
				delay = 0;
				currentFrame++;
			}
			if (currentFrame == totalFrame)
			{
				currentFrame = 0;
			}
		}
	}
}
