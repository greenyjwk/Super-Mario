using Game1;
using Mario.Enums;
using Mario.Sound;
using Microsoft.Xna.Framework;

namespace Mario.Collision.MarioCollisionHandler.MarioBlockCollisionHandler
{
	public class MarioBlockHandler : IMarioCollisionHandler
    {
        Rectangle intersection;
        public MarioBlockHandler(Rectangle intersection)
        {
            this.intersection = intersection;
        }
        public void HandleCollision(IMario mario,Direction result)
        {
            switch (result)
            {
                case Direction.Up:
                    mario.SetFalling(false);
                    mario.SetIsLand(true);
                    mario.Physics.ResetGravity();
                    mario.Position -= Vector2.UnitY*intersection.Height;
                    MarioLandHandling(mario);
                    break;
                case Direction.Down:
					mario.Position += Vector2.UnitY* intersection.Height;
                    mario.Physics.ResetGravity();
                    mario.SetFalling(true);
					SoundManager.Instance.PlaySoundEffect(SoundString.bump);
                    break;
                case Direction.Left:
                   
                        mario.Physics.ResetHorizontal();
                        mario.Position -= Vector2.UnitX * intersection.Width;
                    
                    break;
                case Direction.Right:
                   
                        mario.Physics.ResetHorizontal();
                        mario.Position += Vector2.UnitX * intersection.Width;
                    
                    break;
               
            }
        }
        public void MarioLandHandling(IMario mario)
        {
            if (mario.IsJump())
            {
                if (mario.Physics.XVelocityResponse() >= CollisionUtil.marioMinVelocity)
                {
                    mario.GoRight();
                }
                else if (mario.Physics.XVelocityResponse() <= -CollisionUtil.marioMinVelocity)
                {
                    mario.GoLeft();
                }
                else
                {
                    mario.NoInput();
                }
            }
        }

    }
}
