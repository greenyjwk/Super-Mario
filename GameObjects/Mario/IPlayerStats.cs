namespace Mario.GameObjects.Mario
{
	public interface IPlayerStats
	{
		int Lives { get; set; }
		int Score { get; set; }
		float ScoreMultiplier { get; set; }
	}
}
