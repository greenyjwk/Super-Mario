using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.Classes.BlocksClasses
{
	public abstract class Item : IItem ,ICollidable
    {
        protected ISprite ItemSprite { get; set; }
        private Vector2 ItemLocation;
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)ItemLocation.X, (int)ItemLocation.Y, ItemSprite.Width, ItemSprite.Height);
            }
        }
        private Vector2 maxVelocity = new Vector2(8.0f, 8.0f);
        public Vector2 MaxVelocity { get => maxVelocity; }
        private Vector2 velocity = Vector2.Zero;
        public Vector2 Velocity { get => velocity; set => velocity = value; }

        public GravityManagement gravityManagement { get; set; }
		public Vector2 Position { get => ItemLocation; set => ItemLocation = value; }
        public bool Island { get; set; }
        public Vector2 Force { get ; set; }

        protected Item(Vector2 location)
        {
            ItemLocation = location;
            Island = false;
            gravityManagement = new GravityManagement(this);
            velocity = Vector2.UnitX;

			ItemSprite = SpriteFactory.Instance.CreateSprite(ItemFactory.Instance.GetSpriteDictionary[GetType()]);

		}
        public virtual void Update()
        {
            ItemSprite.Update();
            gravityManagement.Update();
            Move();
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ItemSprite.Draw(spriteBatch, ItemLocation);
        }
        public virtual void IsLandTrue()
        {

            gravityManagement.ResetGravity();
            Island = true;
        }

        public virtual void IsLandFalse()
        {
            Island = false;
        }

        public virtual bool IsStarman()
        {
            return false;
        }

        public virtual void TurnLeft()
        {
            velocity = -Vector2.UnitX;
        }

        public virtual void TurnRight()
        {
            velocity = Vector2.UnitX;
        }
        public virtual void Move()
        {
            ItemLocation += velocity;
        }

        public virtual bool IsCoin()
        {
            return false;
        }

        public virtual void SetContainsItem(String item)
        { }
    }
}
