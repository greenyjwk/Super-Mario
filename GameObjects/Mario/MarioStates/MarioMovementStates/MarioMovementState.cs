using Mario.Interfaces.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;
using Mario.Enums;

namespace Mario.MarioStates.MarioMovementStates
{
    public abstract class MarioMovementState : IMovementEventBehavior
    {
        private IMario mario;
        protected IMario Mario { get => mario; set => mario = value; }

        public abstract MarioMovementType MarioMovementType { get; }

        protected MarioMovementState(IMario mario)
        {
            Mario = mario;
        }
        public virtual void GoDown()
        {
            //NO-OP by default
        }

        public virtual bool IsActive()
        {
            return true;
        }
     
        public virtual void GoLeft()
        {
            mario.Physics.MoveLeft();
        }

        public virtual void GoRight()
        {
            mario.Physics.MoveRight();
        }
        public virtual void GoUp()
        {

        }
        public virtual void NoInput()
        {

        }
        public virtual void BeDead()
        {
            Mario.MarioMovementState = new DeadMarioMovementState(Mario);
        }
    }
}

