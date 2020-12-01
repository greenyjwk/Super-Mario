using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public interface IController:IUpdateable
    {
		void Initialize(IMario mario);
    }
}
