using Game1;
using Mario.AbstractClass;
using Mario.BlockStates;
using Mario.Enums;
using Mario.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Items
{
   public class FireballDisappearState : ProjectileState
    {
        
      
        public FireballDisappearState(IProjectile fireball) : base(fireball)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }

    }
}
