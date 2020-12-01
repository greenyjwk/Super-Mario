using Game1;
using Mario.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.Classes.BlocksClasses
{
	public abstract class Projectile : IProjectile, ICollidable
    {
        protected ISprite ProjectileSprite { get; set; }
        private Vector2 ProjectileLocation;
        public static IMario Mario { get { return (IMario)GameObjectManager.Instance.GameObjectList.Peek(typeof(IMario)); } }
      
        public float XVelocity { get; set; }
        public GravityManagement gravityManagement { get; set; }
        public ProjectileState ProjectileState { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)ProjectileLocation.X, (int)ProjectileLocation.Y, ProjectileSprite.Width, ProjectileSprite.Height);
            }
        }

       
		public Vector2 Position { get => ProjectileLocation; set => ProjectileLocation = value; }
        public bool Island { get; set; }
        public Vector2 Velocity { get; set ; }
        public Vector2 Force { get; set; }

        protected Projectile(Vector2 location)
        {
            ProjectileLocation = location;
            gravityManagement = new GravityManagement(this);
            Island = false;
        }
        public virtual void Update()
        {
            ProjectileSprite.Update();
            if (!Island) { gravityManagement.Update(); }
            Position += Vector2.UnitX*XVelocity;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            ProjectileSprite.Draw(spriteBatch, ProjectileLocation);
        }
		
		public virtual void IsLandTrue()
        {
            gravityManagement.ReverseYVelocity();
            Island = true;
        }
        public virtual void IsLandFalse()
        {
            Island = false;
        }

        public virtual void React()
        {
            //Need to override
        }
        public virtual void MovingLeft()
        {

        }

        public virtual void SetContainsItem(String item)
        { }
    }
}
