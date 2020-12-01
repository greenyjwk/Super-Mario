using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Game1
{
	public interface IEnemy: IGameObject, IPhysicsBody
    {
        bool KoopaStompedCounted { get; set; }
        Vector2 EnemyLocation { get;  }
        void Beflipped();
        void BeStomped();

        void TurnLeft();
        void TurnRight();

        bool IsKoopaStomped();
        bool IsFlipped();
        bool IsGoomba();
        bool IsKoopa();
        bool IsLeftStomped();
        bool IsRightStomped();
        

        GravityManagement gravityManagement { get; set; }
        IEnemyState EnemyState { get; set; }
        void IsLandTrue();
        void IsLandFalse();
    }
}
