using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Sprite
{
    public interface ITextSprite : IGameObject
    {
        string Text { get; set; }
        Vector2 Location { get; set; }
        bool IsFlying { get; set; }
        int InitialY { get; set; }
    }
}
