using Mario.Enums;
using Microsoft.Xna.Framework;

namespace Mario.Collision
{
	public class CollisionUtility
    {
        private Direction DirectionOfCollision { get; set; }
        public Rectangle Intersection { get; set; }
        public CollisionUtility()
        {
        }
        public Direction Collision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            Intersection = Rectangle.Intersect(firstRecDetect, secondRecDetect);
                if (!Intersection.IsEmpty)
                {
                    if (Intersection.Height <= Intersection.Width)
                    {
                        DirectionOfCollision = DetectTopOrBottomCollision(firstRecDetect, secondRecDetect);
                    }
                    else if (Intersection.Height > Intersection.Width)
                    {
                       DirectionOfCollision = DetectLeftOrRightCollision(firstRecDetect, secondRecDetect);
                    }
                }
                else { DirectionOfCollision = Direction.None; }
            
            return DirectionOfCollision;

        }  
        private static Direction DetectTopOrBottomCollision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            if (firstRecDetect.Bottom >= secondRecDetect.Top && firstRecDetect.Bottom <= secondRecDetect.Bottom)
            {
                return Direction.Up;
            }
            else
            {
                return Direction.Down;
            }
           
        }
        private static Direction DetectLeftOrRightCollision(Rectangle firstRecDetect, Rectangle secondRecDetect)
        {
            if (firstRecDetect.Right > secondRecDetect.Left && firstRecDetect.Right < secondRecDetect.Right)
            {
                return Direction.Left;
            }
            else 
            {
                return Direction.Right;
            }
          
        }
    }
}
