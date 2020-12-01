using Game1;
using Microsoft.Xna.Framework;

namespace Mario.CameraClasses
{
	public class Camera : ICamera
    {
        public Vector2 Location { get; set; }
        public Rectangle InnerBox { get; set; }
        public Matrix Transform { get; private set; }
        public Camera()
        {
			Location = Vector2.Zero;      
			Transform = Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, CameraUtil.zero));
            InnerBox = new Rectangle();
        }

        public void MoveRight(float distance)
        {
            Location = new Vector2(Location.X + distance, Location.Y);
            Transform = Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, CameraUtil.zero));
        }
        public void MoveUp(float distance)
        {
            Location = new Vector2(Location.X, Location.Y+ distance);
            Transform = Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, CameraUtil.zero));
           
        }
        public void MoveDown(float distance)
        {
            Location = new Vector2(Location.X, Location.Y - distance);
            Transform = Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, CameraUtil.zero));
        }
        public bool IsOffSideOfScreen(Rectangle box)
        {
            return box.Right <= InnerBox.Left || box.Left >= InnerBox.Left + CameraUtil.resolutionWidth;
        }
        public bool IsOffTopOrBottomOfScreen(Rectangle box)
        {
            return box.Top <= CameraUtil.zero || box.Bottom >= CameraUtil.resolutionHeight;
            
        }
        public void ResetCameraLocation(Rectangle box)
        {
            Location = Vector2.UnitX*(box.Location.X - CameraUtil.cameraOffset);
        }
    }
}