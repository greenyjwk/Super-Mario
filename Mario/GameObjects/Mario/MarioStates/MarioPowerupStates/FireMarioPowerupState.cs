using Game1;
using Mario.Classes.BlocksClasses;
using Mario.Enums;
using Mario.HeadUpDesign;
using Mario.ItemClasses;
using Mario.XMLRead;
using Microsoft.Xna.Framework;
using System;

namespace Mario.MarioStates.MarioPowerupStates
{
	internal class FireMarioPowerupState : MarioPowerupState
	{
        int counter;
        bool fire;
        public FireMarioPowerupState(IMario mario) : base(mario)
		{
            counter = 0;
            fire = true;
        }

		public override void BeFire()
		{
		}
        public override void ThrowProjectile()
        {
            counter++;
            if (counter == 20 && !fire)
            {
                fire = true;
            }
            if (fire)
            {
                Vector2 launchPosition = Mario.Position;
                GameObjectManager.Instance.GameObjectList.Add(new Fireball(launchPosition));
                counter = 0;
                fire = false;
            }
            
        }

		
		public override void TakeDamage()
		{
			Mario.BeNormal();
            Timer.ExtendTime(TimerUtil.Two);
            Timer.SetTimeRunning(true);
            FloatingTimeBar.CreateNewTimeAnimation(Mario, TimerUtil.Two * TimerUtil.ExtentTime);
        }
    }
}