namespace Mario.Interfaces.GameObjects
{
	public interface IMovementEventBehavior
	{
		void GoUp();
		void GoDown();
		void GoLeft();
		void GoRight();
		void NoInput();
	}
}
