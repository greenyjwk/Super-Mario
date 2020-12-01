using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Mario.Classes.BlocksClasses
{
	internal class BlockWithContainer : Block
	{
		public BlockWithContainer(Vector2 location) : base(location)
		{
		}

		public override Rectangle Box => base.Box;

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public override void React()
		{
			BlockState.React();
		}
		public override void Update()
		{
			base.Update();
		}
	}
}
