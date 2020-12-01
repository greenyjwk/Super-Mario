using Mario.BlockStates;
using Mario.Classes.BlocksClasses;
using Mario.GameObjects.Block;
using Microsoft.Xna.Framework;

namespace Mario.BlocksClasses
{
	public class Pipe : Block, IPipe
    {
        
        public Pipe(Vector2 location) : base(location)
        {

            BlockState = new PipeState(this);

        }
    }
}
