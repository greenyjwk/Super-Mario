using Game1;
using Mario;
namespace Mario.MarioCommand
{

    public class BeFireMarioCommand : MarioCommand
    {
        public BeFireMarioCommand(IMario mario):base(mario){  }
        public override void Execute()
        {
			Mario.BeFire();
        }
    }
}
