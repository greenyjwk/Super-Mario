namespace Mario.Interfaces.GameObjects
{
	public interface IPowerupEventBehavior
	{
		void BeDead();

		void BeSuper();

		void BeNormal();

		void BeFire();
		void BeStar();

		void TakeDamage();
	}
}
