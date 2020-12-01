using Game1;
using Microsoft.Xna.Framework;

namespace Mario.BlocksCommand
{

    public class QuitCommand : ICommand
    {
        private Game game;
        public QuitCommand(Game game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}