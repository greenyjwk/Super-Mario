using Game1;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.AbstractClass
{
	public abstract class Enemy : IEnemy,ICollidable, IMoveable
    {

		private Vector2 enemyLocation = Vector2.Zero;
		public Vector2 EnemyLocation => enemyLocation;
        public IEnemyState EnemyState { get; set; }
        public bool KoopaStompedCounted { get; set; }
        public Rectangle Box
        {
            get
            {
                return new Rectangle((int)enemyLocation.X, (int)enemyLocation.Y, EnemyState.GetWidth, EnemyState.GetHeight);
            }
        }
		
		private Vector2 maxVelocity = new Vector2(8.0f,8.0f);
		public Vector2 MaxVelocity { get => maxVelocity; }

		private Vector2 velocity = Vector2.Zero;
		public Vector2 Velocity { get => velocity; set => velocity = value; }
		public bool Island { get; set; }
        public GravityManagement gravityManagement { get; set; }


        protected Enemy(Vector2 location)
        {
            enemyLocation = location;
			Island = false;
            KoopaStompedCounted = false;
            gravityManagement = new GravityManagement(this);
        }


        public virtual void Update()
        {
            EnemyState.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            EnemyState.Draw(spriteBatch, enemyLocation);
        }

        public virtual void Beflipped()
        {
            EnemyState.Beflipped();
        }

        public virtual void BeStomped()
        {
            EnemyState.BeStomped();
        }

        public virtual void TurnLeft()
        {
            EnemyState.TurnLeft();
        }
       

        public virtual void TurnRight()
        {
            EnemyState.TurnRight();
        }
      
		
		public Vector2 Position { get => enemyLocation; set => enemyLocation = value; }
        public Vector2 Force { get ; set ; }

        public virtual bool IsFlipped()
        {
            return EnemyState.IsFlipped();
        }

        public virtual bool IsGoomba()
        {
            return EnemyState.IsGoomba();
        }

        public virtual bool IsKoopa()
        {
            return EnemyState.IsKoopa();
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

		public virtual void Move()
		{
			enemyLocation += velocity;
		}

        public virtual bool IsLeftStomped()
        {
            return EnemyState.IsLeftStomped();
        }

        public virtual bool IsRightStomped()
        {
            return EnemyState.IsRightStomped();
        }
        public virtual bool IsKoopaStomped()
        {
            return EnemyState.IsKoopaStomped();
        }
        public virtual void SetContainsItem(String item)
        {
        }

    }
}
