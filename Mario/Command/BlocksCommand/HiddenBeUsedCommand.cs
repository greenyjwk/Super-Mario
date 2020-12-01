using Game1;

namespace Mario.BlocksCommand
{

    public class HiddenBeUsedCommand : ICommand
    {
        private Game1 myMario;
        public HiddenBeUsedCommand(Game1 hiddenBeUsed)
        {
            myMario = hiddenBeUsed;
        }
        public void Update()
        {
            foreach (IBlock block in myMario.blockList)
            {
                if (block.IsHiddenBlock())
                {
                    block.React();
                }
            }
        }
    }
}