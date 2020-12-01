using Game1;
using Mario.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.AbstractClass
{
     public class AnimatedSprite : ISprite
    {
        protected Texture2D SpriteSheet { get; set; }
        protected int SpriteWidth { get=>SpriteSheet.Width; }
        protected int SpriteHeight { get => SpriteSheet.Height; }
        protected int Rows { get; set; }
        protected int Columns { get; set; }
        protected int CurrentFrame { get; set; }
        protected int TotalFrame { get; set; }
        protected int Delay { get; set; }

        public AnimatedSprite(Texture2D spriteSheet, int rows, int columns)
        {
            SpriteSheet = spriteSheet;
            Rows = rows;
            Columns = columns;
            CurrentFrame = SpriteUtil.Zero;
            TotalFrame = rows * columns;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
			Draw(spriteBatch, location, Color.White);
        }
		public virtual int Width => SpriteWidth / Columns;
		public virtual int Height => SpriteHeight / Rows;
		public virtual void Update()
        {
            Delay++;
            if (Delay == SpriteUtil.delayUtil)
            {
                Delay = SpriteUtil.Zero;
                CurrentFrame++;
            }
            if (CurrentFrame == TotalFrame)
            {
                CurrentFrame = SpriteUtil.Zero;
            }
        }

		public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
		{
			int width = SpriteSheet.Width / Columns;
			int height = SpriteSheet.Height / Rows;
			int row = (int)((float)CurrentFrame / (float)Columns);
			int column = CurrentFrame % Columns;

			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

			spriteBatch.Draw(SpriteSheet, destinationRectangle, sourceRectangle, color);
		}
	}
}