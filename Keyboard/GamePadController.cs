using Game1;
using Mario.BlocksCommand;
using Mario.MarioCommand;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mario
{
    public class GamePadController : IController
    {
        private Game1 Game { get; set; }
        private IDictionary<Buttons,ICommand> commandList;
        private int delay;
        public GamePadController(Game1 game)
        {
            this.Game = game;
			commandList = new Dictionary<Buttons, ICommand>();
            delay = 0;
        }
        public void Update()
        {
            delay++;
            if (delay == 5)
            {
                GamePadState currentState = GamePad.GetState(PlayerIndex.One);

				foreach (KeyValuePair<Buttons, ICommand> commandPair in commandList)
				{
					if (currentState.IsButtonDown(commandPair.Key))
						commandPair.Value.Execute();
				
                }

                delay = 0;
            }
			

        }

		public void Initialize(IMario mario) { 
		
			commandList.Add(Buttons.Start, new QuitCommand(Game));
			commandList.Add(Buttons.DPadLeft, new MoveMarioLeftCommand(mario));
			commandList.Add(Buttons.A,new MoveMarioUpCommand(mario));
			commandList.Add(Buttons.DPadDown, new MoveMarioDownCommand(mario));
			commandList.Add(Buttons.DPadRight, new MoveRightMarioCommand(mario));
			commandList.Add(Buttons.B, new SprintAndFireProjectileMarioCommand(mario));
		}
	}
}
