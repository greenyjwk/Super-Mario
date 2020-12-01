using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Mario.MarioCommand;
using Mario.BlocksCommand;
using Game1;
using System.Linq;
using System.Diagnostics;

namespace Mario
{
    public class Keyboards : IController
    {
        private Dictionary<Keys, ICommand> keyboardMap;
        private Keys[] previous;
        public Keyboards()
        {
        }

        public void Initialize(IMario mario)
        {
			keyboardMap = new Dictionary<Keys, ICommand>
			{
				{ Keys.Z, new MoveMarioUpCommand(mario) },
				{ Keys.Down, new MoveMarioDownCommand(mario) },
				{ Keys.Left, new MoveMarioLeftCommand(mario) },
				{ Keys.Right, new MoveRightMarioCommand(mario) },
				{ Keys.Y, new BeNormalMarioCommand(mario) },
				{ Keys.U, new BeSuperMarioCommand(mario) },
				{ Keys.I, new BeFireMarioCommand(mario) },
				{ Keys.O, new BeDeadMarioCommand(mario) },
				{ Keys.P, new BeStarMarioCommand(mario) },
				{ Keys.Q, new QuitCommand(Game1.Instance) },
				{ Keys.X, new SprintAndFireProjectileMarioCommand(mario) },
				{ Keys.R, new ResetCommand(Game1.Instance) },
                { Keys.T, new PauseCommand(Game1.Instance) },
                { Keys.None, new NoInputCommand(mario) }
			};
		}
        public void Update()
        {
            Keys[] getkeys =Keyboard.GetState().GetPressedKeys();
              if (getkeys.Length == 0)
               {
                   keyboardMap[Keys.None].Execute();
            }
            foreach (Keys key in getkeys)
            {
                if (key.Equals(Keys.Z))
                {
                    if (!previous.Contains(key))
                    {
                        keyboardMap[key].Execute();
                    }
                }
                else if (key.Equals(Keys.T))
                {
                    if (!previous.Contains(key))
                    {
                        keyboardMap[key].Execute();
                    }
                }
                else if(keyboardMap.ContainsKey(key))
                {
                    keyboardMap[key].Execute();
                }
            }
            previous = getkeys;
        }
      
		
    }

}