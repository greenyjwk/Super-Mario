using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
	public interface IEnemyState :  IUpdateable
    {
        int GetWidth { get; }
        int GetHeight { get; }
    void Beflipped();
        void BeStomped();
        void TurnLeft();
        void TurnRight();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        bool IsKoopaStomped();
        bool IsFlipped();
        bool IsLeftStomped();
        bool IsRightStomped();
        bool IsGoomba();
        bool IsKoopa();
     


    }
}
