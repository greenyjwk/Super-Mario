using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
   public interface IProjectileState
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Update();
        void React();
    }
}
