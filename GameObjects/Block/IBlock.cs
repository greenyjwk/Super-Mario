using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Game1
{
	public interface IBlock : IGameObject
	{
		
        string ItemContained { get; set; }
        bool ToUnderground { get; set; }
        void SetToUnderground(string flag);
        void React();
        Vector2 Position { get; set; }
	
        IBlockState BlockState { get; set; }
       
    }
}
