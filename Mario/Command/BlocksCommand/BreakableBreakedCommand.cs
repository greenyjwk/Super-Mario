using Game1;

namespace Mario.BlocksCommand

{
    class BreakableBreakedCommand : ICommand
    {
        private Game1 myMario;
        public BreakableBreakedCommand(Game1 beBreak)
        {
            myMario = beBreak;
        }
        public void Update()
        {
           
        }
    }
}
