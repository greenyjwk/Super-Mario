using Mario.BlockStates;
using Mario.Interfaces.GameObjects;


namespace Game1
{
	public interface IProjectile : IGameObject, IPhysicsBody
    {
        
  
        ProjectileState ProjectileState { get; set; }
        void IsLandTrue();
        void IsLandFalse();
        void React();
        GravityManagement gravityManagement { get; set; }
    }
   
}
      
