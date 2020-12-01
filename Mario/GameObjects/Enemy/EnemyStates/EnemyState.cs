using Game1;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.AbstractClass
{
    public abstract class EnemyState : IEnemyState
    {
        protected ISprite EnemySprite { get; set; }
        protected IEnemy Enemy { get; set; }
        protected Vector2 XVelocity { get; set; }
        public int GetWidth
        {
            get
            {
                return EnemySprite.Width;
            }
        }
        public int GetHeight
        {
            get
            {
                return EnemySprite.Height;
            }
        }


        protected EnemyState(IEnemy enemy)
        {
            Enemy = enemy;
			try
			{
				EnemySprite = SpriteFactory.Instance.CreateSprite(EnemyFactory.Instance.GetSpriteDictionary[enemy.GetType()][GetType()]);
			}catch(System.Collections.Generic.KeyNotFoundException)
			{
				Console.WriteLine(enemy.GetType().Name + " ," + this.GetType().Name);
			}

		}
		public virtual void Beflipped()
        {
            //Need to be overriden
        }

        public virtual void BeStomped()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            EnemySprite.Draw(spriteBatch, location);
        }

        public virtual void TurnLeft()
        {

        }

        public virtual void TurnRight()
        {

        }

        public virtual void Update()
        {
            EnemySprite.Update();
            Enemy.gravityManagement.Update();
        }

        public virtual bool IsFlipped()
        {
            return false;
        }

        public virtual bool IsGoomba()
        {
            return false;
        }

        public virtual bool IsKoopa()
        {
            return false;
        }
      

        public virtual bool IsLeftStomped()
        {
            return false;
        }

        public virtual bool IsRightStomped()
        {
            return false;
        }
        public virtual bool IsKoopaStomped()
        {
            return false;
        }
    

      
    }
}
