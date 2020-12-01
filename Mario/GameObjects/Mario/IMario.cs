using Mario.GameObjects.Mario;
using Mario.Interfaces.GameObjects;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
	public interface IMario : IGameObject, IMovementEventBehavior, IPowerupEventBehavior, IPhysicsBody, IPlayerStats
    {
        bool IsStarMario();
        bool IsActive();
        bool IsAtEnd();
        bool IsJump();
        void ThrowProjectile();
        MarioMovementState MarioMovementState { get; set; }
        MarioPowerupState MarioPowerupState { get; set; }
        PhysicsMario Physics { get;set; }
        bool Fall { get; set; }
        bool IsCrouch { get; set; }
        void SetIsLand(bool Land);
        void SetFalling(bool fall);
        void Sprint();
		void Draw(SpriteBatch spriteBatch, Color c);
		ISprite MarioSprite { get; set; }
    }
}
