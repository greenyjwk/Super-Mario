using Game1;
using Mario.Classes;
using Mario.Classes.BlocksClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.BlockStates
{
    public abstract class ProjectileState : IProjectileState
    {
        protected ISprite ProjectileSprite { get; set; }
        protected IProjectile Projectile { get; set; }
        public int getWidth
        {
            get
            {
                return ProjectileSprite.Width;
            }
        }
        public int getHeight
        {
            get
            {
                return ProjectileSprite.Height;
            }
        }
        protected ProjectileState(IProjectile Projectile)
        {
            this.Projectile = Projectile;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            ProjectileSprite.Draw(spriteBatch, location);
        }
        public virtual void Update()
        {
            ProjectileSprite.Update();
        }

      
        public virtual void React()
        {
        }

    }


}

