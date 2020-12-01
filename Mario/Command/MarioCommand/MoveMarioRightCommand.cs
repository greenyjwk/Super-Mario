using Game1;

namespace Mario.MarioCommand

{

    public class MoveRightMarioCommand : MarioCommand
    {
        public MoveRightMarioCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
            if (!Game1.Instance.IsPause)
                Mario.GoRight();
        }
    }
}
