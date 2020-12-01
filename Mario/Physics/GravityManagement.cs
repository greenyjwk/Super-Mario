using Game1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class GravityManagement : IPhysicsBody
    {
        IPhysicsBody physicsBody;
        float Gravity { get; set; }
        float YVelocity { get; set; }
        public Vector2 Position { get ; set; }
        public bool Island { get; set ; }
        public Vector2 Velocity { get; set; }
        public Vector2 Force { get ; set ; }

        public GravityManagement(IPhysicsBody physicsBody)
        {
            this.physicsBody = physicsBody;
            YVelocity = PhysicsUtil.zero;
            Gravity = PhysicsUtil.gravity;
            Island = physicsBody.Island;
        }
        public void ReverseYVelocity()
        {
            YVelocity = -YVelocity / PhysicsUtil.reverseYVelocityDivider;
        }
        public void OppositeYVelocity()
        {
            YVelocity = -YVelocity;

        }
        public void ResetGravity()
        {
            YVelocity = PhysicsUtil.zero;
        }
        private void ApplyGtravity()
        {
            physicsBody.Position += Vector2.UnitY * YVelocity;
            YVelocity += Gravity;
        }

        public void Update()
        {
            if (!Island)
                ApplyGtravity();
        }
        
    }
}
