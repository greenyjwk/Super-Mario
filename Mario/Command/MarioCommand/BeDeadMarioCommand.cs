using Game1;
using Mario.MarioCommand;
namespace Mario.MarioCommand

{

    public class BeDeadMarioCommand : MarioCommand
    {
        public BeDeadMarioCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
            Mario.BeDead();

        }
    }
}
