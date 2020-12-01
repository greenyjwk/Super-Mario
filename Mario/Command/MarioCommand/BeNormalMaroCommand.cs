using Game1;
using Mario.MarioCommand;

namespace Mario.MarioCommand
{

    public class BeNormalMarioCommand : MarioCommand
    {
        public BeNormalMarioCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.BeNormal();

        }
    }
}
