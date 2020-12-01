using Game1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Mario.Sound;

namespace Game1
{
    public class PhysicsMario
    {
       
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        private float MaxYVelocity { get; set; }
        IMario mario;
        public PhysicsMario(IMario mario)
        {
            this.mario = mario;
            XVelocity = PhysicsUtil.zero;
            YVelocity = PhysicsUtil.zero;
            MaxYVelocity = PhysicsUtil.maxYVelocity;
        }
        public void Sprint()
        {
            XVelocity *= PhysicsUtil.sprintVelocity;
        }
     
        public void MoveRight()
        {
            if (XVelocity < PhysicsUtil.firstPhaseXVelocity)
            {
                XVelocity += PhysicsUtil.maxXVelocity * PhysicsUtil.firstPhaseMultiplier;
            }
            else
            {
                XVelocity += PhysicsUtil.maxXVelocity * PhysicsUtil.secondPhaseMultiplier;
            }
            if (XVelocity > PhysicsUtil.maxXVelocity)
            {
                XVelocity = PhysicsUtil.maxYVelocity;
            }
        }
        public void MoveLeft()
        {
            if (XVelocity >= -PhysicsUtil.firstPhaseXVelocity) { 
            
                XVelocity -= PhysicsUtil.maxXVelocity * PhysicsUtil.firstPhaseMultiplier;
            }
            else
            {
                XVelocity -= PhysicsUtil.maxXVelocity * PhysicsUtil.secondPhaseMultiplier;
            }
        }
        public void JumpLeft()
        {
            if (mario.IsActive())
            {
                XVelocity -= PhysicsUtil.jumpFriction;

                if (XVelocity < -PhysicsUtil.maxXVelocity)
                {
                    XVelocity = -PhysicsUtil.maxXVelocity;
                }
            }
        }
        public void JumpRight()
        {
            if (mario.IsActive())
            {
                XVelocity += PhysicsUtil.jumpFriction;

                if (XVelocity > PhysicsUtil.maxXVelocity)
                   {
                     XVelocity = PhysicsUtil.maxXVelocity;
            }
            }
        }
        public void Jump()
        {
            if (mario.Island)
            {
                mario.Island = false;
                mario.MarioMovementState.GoUp();
                YVelocity += PhysicsUtil.upForce;
                SoundManager.Instance.PlaySoundEffect("marioJump");
            }
         }
        public void NotJump()
        {
            if (YVelocity >PhysicsUtil.notJumpPhaseUtil)
            {
                YVelocity =PhysicsUtil.notJumpPhaseOffset;
            }
        }
       
        public void CheckFalling()
        {
            if (YVelocity<PhysicsUtil.fallDownCheckUtil)
            {
                mario.SetFalling(true);
                mario.SetIsLand(false);
            }
            else
            {
                mario.SetFalling(false);
            }
        }
        public void UpdateVertical()
        {
            mario.Position -= Vector2.UnitY * YVelocity;
            if (YVelocity >= PhysicsUtil.fallingPhaseCheckUtil)
            {
                YVelocity *=PhysicsUtil.upwardMultiplier;
            }
            else if (YVelocity <= PhysicsUtil.fallingPhaseCheckUtil)
            {

                YVelocity -= MaxYVelocity * PhysicsUtil.fallDownMultiplier;

            }
        }
        public void UpdateHorizontal()
        {
            mario.Position += Vector2.UnitX * XVelocity;
            if (mario.Island)
            {
                XVelocity *= PhysicsUtil.notJumpPhaseUtil;
            }
            else
            {
                XVelocity = PhysicsUtil.zero;
            }
        }
        public float XVelocityResponse()
        {
            return XVelocity;
        }
        public float YVelocityResponse()
        {
            return YVelocity;
        }
        public void ResetGravity()
        {
            YVelocity = PhysicsUtil.zero;
        }
        public void ResetHorizontal()
        {
            XVelocity = PhysicsUtil.zero;
        }
        public void ReverseYVelocity()
        {
            YVelocity = -YVelocity/PhysicsUtil.reverseYVelocityDivider;
        }
      
        public void Update()
        {
            UpdateHorizontal();
            UpdateVertical();
            CheckFalling();
        }
    }
}
