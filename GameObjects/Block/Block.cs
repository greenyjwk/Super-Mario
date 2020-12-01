using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.Classes.BlocksClasses
{
	public abstract class Block : IBlock, ICollidable
    {
        private Vector2 BlockLocation;
        private String itemContained = "";
        private bool toUnderground = false;
        public IBlockState BlockState { get; set; }
        public String ItemContained { get => itemContained; set => itemContained = value; }
        public bool ToUnderground { get => toUnderground; set => toUnderground = value; }
        public virtual Rectangle Box
        {
            get
            {
                return new Rectangle((int)BlockLocation.X, (int)BlockLocation.Y, BlockState.GetWidth, BlockState.GetHeight);
            }
        }
        protected Block(Vector2 location)
        {
            BlockLocation = location;
            
        }
        public virtual void Update()
        {
            BlockState.Update();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            BlockState.Draw(spriteBatch, BlockLocation);
        }
        public virtual void React()
        {
            //Need to override.
        }
        public virtual void SetToUnderground(String flag)
        {
            if (flag.Equals("True"))
                ToUnderground = true;
            else
                ToUnderground = false;
        }
        public Vector2 Position { get => BlockLocation; set => BlockLocation = value; }
	}
}
