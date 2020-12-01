using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IPhysicsBody
    {
		Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Force { get; set; }
        bool Island { get; set; }
    }
}
