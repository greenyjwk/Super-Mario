using Game1;
using Mario.BlockStates;
using Mario.Display;
using Mario.HeadUpDesign;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sound;
using Mario.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects.Decorators.Special_Event_Behaviors
{

	internal enum SlidingStates
	{
		SLIDING_DOWN = 0,
		WALKING_RIGHT = 1,
		HOLDING = 2,
		INITIAL = 3,
		EXIT = 3
	}
	class SlideDownFlagDecorator :MarioSpecialEventDecorator
	{
		private Vector2 locationOfBase = Vector2.Zero;
		private SlidingStates slidingState = SlidingStates.INITIAL;
		private float holdingTime = MarioUtil.WinConditionHoldingTime;

        public SlideDownFlagDecorator(IMario mario, Vector2 locationOfBase):base(mario)
		{
			this.locationOfBase = locationOfBase;            
			slidingState = SlidingStates.SLIDING_DOWN;
            ScoringSystem.Instance.AddPointsForFinalPole(mario.Box);
            LevelCounter.Instance.LevelUp();
            SoundManager.StopSong();
            SoundManager.Instance.PlaySoundEffect("clearStage");
        }

		public override void Update()
		{
			switch (slidingState)
			{
				case SlidingStates.SLIDING_DOWN:
                    Timer.StopTimer();
                    if (Math.Abs(DecoratedMario.Position.Y - locationOfBase.Y) > DecoratorUtil.locationOffset)
					{
						DecoratedMario.Position += Vector2.UnitY * DecoratorUtil.locationOffset;
					}
					else
					{
						slidingState = SlidingStates.WALKING_RIGHT;
					}
					break;
				case SlidingStates.WALKING_RIGHT:
					if (DecoratedMario.Position.X > GameObjectManager.Instance.EndOfLevelXPosition + DecoratorUtil.walkRightOffset) 
					{
						slidingState = SlidingStates.HOLDING;
					}
					else
					{
						this.DecoratedMario.GoRight();
						this.DecoratedMario.Position += Vector2.UnitX * DecoratorUtil.Double;
                    }

                    break;
				case SlidingStates.HOLDING:
					if (holdingTime <= 0)
					{
						holdingTime--;
					}
					else
					{
						slidingState = SlidingStates.EXIT;
					}
					break;
				default:
					RemoveSelf();
					break;
			}
			
		}

		public override bool IsActive()
		{
			return false;
		}
		public override void RemoveSelf()
		{
            base.RemoveSelf();
            GameObjectManager.Instance.SetInitialValuesCamera();
            GameObjectManager.Instance.LifeDisplayTrigger = false;
            GameObjectManager.Instance.LoadContent();
            GameObjectManager.Instance.LifeDisplayTrigger = true;

        }
		
	}
}
