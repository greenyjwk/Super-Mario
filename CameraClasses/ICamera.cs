using Microsoft.Xna.Framework;

namespace Game1
{
	public interface ICamera
    {
        Vector2 Location { get; }
        Matrix Transform { get; }
        Rectangle InnerBox { get; set; }
        void ResetCameraLocation(Rectangle box);
        void MoveRight(float move);
        bool IsOffSideOfScreen(Rectangle box);
        void MoveUp(float move);
        void MoveDown(float move);

        bool IsOffTopOrBottomOfScreen(Rectangle box);
       
    }
}