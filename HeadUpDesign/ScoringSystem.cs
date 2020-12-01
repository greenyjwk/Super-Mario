using Mario.Interfaces.GameObjects;
using Microsoft.Xna.Framework;

namespace Mario.HeadUpDesign
{
	public class ScoringSystem
    {
        private int score = 0;
        public int Score { get { return score; } }
        private ScoreMultiplierUtility multilperForScore;
        private static readonly ScoringSystem instance = new ScoringSystem();
        public static ScoringSystem Instance { get { return instance; } }
        private ScoringSystem()
        {
           multilperForScore = new ScoreMultiplierUtility();
        }
        public void ResetScore()
        {
            score = ScoreUtil.ZeroScore;
        }

        public void AddPointsForBreakingBlock()
        {
            score += ScoreUtil.BreakingBlockScore;
        }
        public void AddPointsForCollectingItem(IGameObject item)
        {
            score += ScoreUtil.ItemCollectedScore;
            FloatingScoreBar.CreateNewScoreAnimation(item, ScoreUtil.ItemCollectedScore);
        }
        public void AddPointsForCoin()
        {
            score += ScoreUtil.CoinCollectedScore;
        }
        public void AddPointsForRestTime()
        {
            score += ScoreUtil.SecondBonusScore;
        }
        public void AddPointsForStompingEnemy(IGameObject enemy)
        {
            int scoreToAdd = multilperForScore.DetermineStompSequence();
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyBelowBlockHit(IGameObject enemy)
        {
            int scoreToAdd = ScoreUtil.EnemyBelowBlockHitScore;
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFireballGoombaHit(IGameObject goomba)
        {
            int scoreToAdd = ScoreUtil.SpecialGoombaHitScore;
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(goomba, scoreToAdd);
        }
        public void AddPointsForFireballKoopaHit(IGameObject koopa)
        {
            int scoreToAdd = ScoreUtil.SpecialKoopaHitScore;
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(koopa, scoreToAdd);
        }
        public void AddPointsForInitiatingShell(IGameObject enemy)
        {
            int scoreToAdd = multilperForScore.DetermineShellInitializationSequence(enemy);
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyHitByShell(IGameObject enemy)
        {
            int scoreToAdd = multilperForScore.DetermineShellHitSequence(enemy);
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFinalPole(Rectangle marioDestination)
        {
            int scoreToAdd = ScoreUtil.OffTheFlagFifthScore;
            if (marioDestination.Y < ScoreUtil.FlagFirst)
            {
                scoreToAdd = ScoreUtil.OffTheFlagHighestScore;
            }
            else if (marioDestination.Y <ScoreUtil.FlagSecond)
            {
                scoreToAdd = ScoreUtil.OffTheFlagSecondScore;
            }
            else if (marioDestination.Y < ScoreUtil.FlagThird)
            {
                scoreToAdd = ScoreUtil.OffTheFlagThirdScore;
            }
            else if (marioDestination.Y < ScoreUtil.FlagForth)
            {
                scoreToAdd = ScoreUtil.OffTheFlagFourthScore;
            }
            score += scoreToAdd;
            FloatingScoreBar.CreateNewScoreAnimation(GameObjectManager.Instance.Mario,scoreToAdd);
        }
        
        public void SetMarioEnemyHitThisIterationToFalse()
        {
           multilperForScore.HitEnemyAlreadyThisIteration = false;
        }
    }
}
