using Game1;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.GameObjects.Decorators
{
	abstract class MarioDecorator: GameObjectDecorator, IMario
	{
		protected MarioDecorator(IMario mario):base(mario)
		{

		}
		
		
		public MarioMovementState MarioMovementState { get => DecoratedMario.MarioMovementState; set => DecoratedMario.MarioMovementState = value; }
		public MarioPowerupState MarioPowerupState { get => DecoratedMario.MarioPowerupState; set => DecoratedMario.MarioPowerupState = value; }
		public PhysicsMario Physics { get => DecoratedMario.Physics; set => DecoratedMario.Physics = value; }
		
		protected IMario DecoratedMario { get => (IMario)DecoratedObject; }
		public Vector2 Position { get => DecoratedMario.Position; set => DecoratedMario.Position = value; }
		public ISprite MarioSprite { get => DecoratedMario.MarioSprite; set => DecoratedMario.MarioSprite = value; }
        public bool Island { get; set; }
        public bool IsCrouch { get => DecoratedMario.IsCrouch; set => DecoratedMario.IsCrouch = value; }
        public Vector2 Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Force { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int Lives { get => DecoratedMario.Lives; set => DecoratedMario.Lives = value; }
		public int Score { get => DecoratedMario.Score; set => DecoratedMario.Score = value; }
		public float ScoreMultiplier { get => DecoratedMario.ScoreMultiplier; set => DecoratedMario.ScoreMultiplier = value; }
        public bool Fall { get ; set ; }

        public void BeFire()
		{
            DecoratedMario.MarioPowerupState.BeFire();
		}

		public void BeNormal()
		{
            DecoratedMario.MarioPowerupState.BeFire();
        }

        public void BeStar()
		{
            DecoratedMario.MarioPowerupState.BeFire();
        }

        public void BeSuper()
		{
            DecoratedMario.MarioPowerupState.BeFire();
        }

        public void BeDead()
		{
            DecoratedMario.MarioPowerupState.BeFire();
        }

        public void GoDown()
		{
			DecoratedMario.GoDown();
		}

		public virtual bool IsActive()
		{
			return DecoratedMario.IsActive();
		}
		public void SetIsLand(bool Land)
		{
			DecoratedMario.SetIsLand(Land);
		}
		public virtual bool IsStarMario()
		{
			return DecoratedMario.IsStarMario();
		}
        

		public virtual void GoLeft()
		{
			DecoratedMario.GoLeft();
		}

		public virtual void NoInput()
		{
			DecoratedMario.NoInput();
		}

		public virtual void GoRight()
		{
			DecoratedMario.GoRight();
		}

		public void ThrowProjectile()
		{
			DecoratedMario.ThrowProjectile();
		}

		public virtual void GoUp()
		{
			DecoratedMario.GoUp();
		}

		public virtual void TakeDamage()
		{
			DecoratedMario.TakeDamage();

        }

        public void Draw(SpriteBatch spriteBatch, Color c)
		{
			DecoratedMario.Draw(spriteBatch, c);
		}

      
        public void SetFalling(bool fall)
        {
            DecoratedMario.SetFalling(fall);
        }

        public void Sprint()
        {
            DecoratedMario.Sprint();
        }

        public bool IsAtEnd()
        {
            return DecoratedMario.IsAtEnd();
        }

        public bool IsJump()
        {
            return DecoratedMario.IsJump();
        }
    }
}
