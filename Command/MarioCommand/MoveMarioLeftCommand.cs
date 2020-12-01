using Game1;

namespace Mario.MarioCommand

{

    public class MoveMarioLeftCommand : MarioCommand
    {
        public MoveMarioLeftCommand(IMario mario):base(mario)
        {        }
        public override void Execute()
        {
            if (!Game1.Instance.IsPause)
                Mario.GoLeft();
        }
    }
}
