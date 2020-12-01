using Mario.Enums;
using Mario.Interfaces.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using Mario.MarioStates.MarioMovementStates;

namespace Mario.MarioStates.MarioPowerupStates
{
	public abstract class MarioPowerupState : IPowerupEventBehavior
	{
		private IMario mario;
		protected IMario Mario { get => mario; set => mario = value; }
		protected MarioPowerupState(IMario mario)
		{
			Mario = mario;
        }

		public virtual bool IsActive()
		{
			return true;
		}

		public virtual void BeFire()
		{
            Mario.MarioPowerupState = new FireMarioPowerupState(Mario);

		}
		public virtual void BeNormal()
		{
			Mario.MarioPowerupState = new NormalMarioPowerupState(Mario);
		}
		public virtual void BeStar()
		{
			
		}
		public virtual void BeSuper()
		{
            Mario.MarioPowerupState = new SuperMarioPowerupState(Mario);
		}
		public virtual void BeDead()
		{
            Mario.MarioPowerupState = new DeadMarioPowerupState(Mario);
        }

	
        public virtual void ThrowProjectile()
        {
            //May need to override
        }

		public virtual void TakeDamage()
		{
			//NO-OP by default
		}
	}
}
