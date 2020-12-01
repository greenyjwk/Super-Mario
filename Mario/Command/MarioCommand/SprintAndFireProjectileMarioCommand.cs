using Game1;

namespace Mario.MarioCommand

{

	public class SprintAndFireProjectileMarioCommand : MarioCommand
    {
     
        public SprintAndFireProjectileMarioCommand(IMario mario):base(mario)
        {
           
        }
        public override void Execute()
        {
            Mario.Sprint();
            Mario.ThrowProjectile();
        }
    }
}
