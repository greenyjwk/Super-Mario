
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game.Sprites
{
    public class TextSprite : ITextSprite
    {
        public string Text { get; set; }

        public Texture2D Texture { get; set; } //= null;
        private SpriteFont font;
        private Vector2 size;
        public Vector2 Location { get; set; }
        public bool IsFlying { get; set; }

        public Rectangle Box { get; set; }
        public int InitialY { get; set; }

        public TextSprite(SpriteFont font)
        {
            this.font = font;
            this.size = new Vector2(SpriteUtil.Zero, SpriteUtil.Zero);
            IsFlying = false;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, Location, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            size = font.MeasureString(Text);
            InitialY = (int)location.Y;
            Box = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            return Box;
        }

        public void Update()
        {
            size = font.MeasureString(Text);
        }
    }
}