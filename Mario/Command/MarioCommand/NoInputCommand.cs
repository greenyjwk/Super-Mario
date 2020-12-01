using Game1;

namespace Mario.MarioCommand
{
	internal class NoInputCommand : ICommand
	{
		private IMario mario;

		public NoInputCommand(IMario mario)
		{
			this.mario = mario;
		}

		public void Execute()
		{
			mario.NoInput();
		}
	}
}