using Game1;

namespace Mario.MarioCommand
{

	public class BeStarMarioCommand : MarioCommand
	{ 
        public BeStarMarioCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.BeStar();
        }
    }
}
