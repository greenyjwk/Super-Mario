using Game1;

namespace Mario.MarioCommand

{

    public class BeSuperMarioCommand : MarioCommand
    {
        public BeSuperMarioCommand(IMario mario):base(mario)
        {
        }
        public override void Execute()
        {
           Mario.BeSuper();

        }
    }
}
