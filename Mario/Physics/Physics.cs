using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Physics
{
    public class Physics
    {
        private static Physics instance = new Physics();
        public static Physics Instance { get => instance; set => instance = value; }
        private Vector2 Gravity{get;set;} 
        IList<IPhysicsBody> PhysicsBodyObject { get; set; }
        public static IList<Tuple<IPhysicsBody, Vector2>> PhysicsList { get ;  }
        public Physics()
        {
            Gravity = new Vector2(PhysicsUtil.zero, PhysicsUtil.gravity);
        }
        internal void ApplyGravity(IPhysicsBody physicsObject)
        {
            ApplyForce(physicsObject,Gravity);
        }
        internal void ApplyForce(IPhysicsBody physicsObject,Vector2 force)
        {
            physicsObject.Velocity += force;
        }
        public void Update()
        {
            for (int i = PhysicsBodyObject.Count - 1; i >= 0; i--)
            {
                ApplyGravity(PhysicsBodyObject[i]);
                ApplyForce(PhysicsList[i].Item1, PhysicsList[i].Item2);

            }
        }

    }
}
