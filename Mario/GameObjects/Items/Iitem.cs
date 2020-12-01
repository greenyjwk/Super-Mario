using Mario.Interfaces.GameObjects;


namespace Game1
{
	public interface IItem : IGameObject, IPhysicsBody
    {

        GravityManagement gravityManagement { get; set; }
       
        bool IsStarman();
        bool IsCoin();
        void IsLandTrue();
        void IsLandFalse();
        void TurnLeft();
        void TurnRight();
    }

}
      
