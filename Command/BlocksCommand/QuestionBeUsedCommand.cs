using Game1;

namespace Mario.BlocksCommand
{

    public class QuestionBeUsedCommand : ICommand
    {
        private Game1 myMario;
        public QuestionBeUsedCommand(Game1 questionBeUsed)
        {
            myMario = questionBeUsed;
        }
        public void Update()
        {
            foreach (IBlock block in myMario.blockList)
            {
                if (block.IsQuestionBlock())
                {
                    block.React();
                }
            }
        }
    }
}
