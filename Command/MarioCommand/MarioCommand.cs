using Game1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.MarioCommand
{
	public abstract class MarioCommand : ICommand
	{
		private IMario mario;
		protected IMario Mario { get => mario; set => mario = value; }
		protected MarioCommand(IMario mario)
		{
			this.mario = mario;
		}
		public abstract void Execute();
	}
}
