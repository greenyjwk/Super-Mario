using Game1;
using Mario.Factory;
using Mario.GameObjects.Decorators;
using Mario.GameObjects.Decorators.Special_Event_Behaviors;
using Mario.HeadUpDesign;
using Mario.MarioStates.MarioMovementStates;
using Mario.MarioStates.MarioPowerupStates;
using Mario.Sound;
using Mario.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Mario
{
	public class Mario : IMario,ICollidable
    {
        private Vector2 location = Vector2.Zero;
		public Vector2 Position { get => location; set => location = value; }
		private MarioMovementState marioMovementState;
		public MarioMovementState MarioMovementState
		{
			get
			{
				return marioMovementState;
			}
			set
			{
				try
				{
					marioMovementState = value;
					MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.GetType()]);
				}catch(System.Collections.Generic.KeyNotFoundException )
				{
					Debug.WriteLine("ERROR: " + MarioPowerupState.GetType().ToString() + " , " + MarioMovementState.MarioMovementType.ToString());
				}
			}
		}
		private MarioPowerupState marioPowerupState;
		public MarioPowerupState MarioPowerupState {
			get {
				return marioPowerupState;
			}
			set
			{
				try
				{
					MarioPowerupState newState = value;
					if (newState.IsActive())
					{
						GameObjectManager.Instance.Mario = new TransitionStateMarioDecorator(this, marioPowerupState, newState);
					}
					else if(!(newState is DeadMarioPowerupState))
					{
						GameObjectManager.Instance.Mario = new TransitionStateMarioDecorator(this, newState, newState);
					}
					marioPowerupState = newState;
					
				}
				catch (System.Collections.Generic.KeyNotFoundException )
				{
					Debug.WriteLine("ERROR: " + MarioPowerupState.GetType().ToString() + " , " + MarioMovementState.MarioMovementType.ToString() + " is not found in the dictionary");
				}
			}
		}
		public ISprite MarioSprite { get; set; }

        public bool Fall { get; set; }
        public bool IsCrouch { get; set; }
        private bool atTheEnd;
        private bool isOnPipe;
        public bool Island { get; set; }
        public Rectangle Box
        {
            get
            {
				return new Rectangle((int)location.X, (int)location.Y, MarioSprite.Width, MarioSprite.Height);                
            }
            
        }
		

        public PhysicsMario Physics { get; set; }
        public Vector2 Velocity { get; set ; }
        public Vector2 Force { get; set ; }
		private int lives = 3;
		public int Lives { get =>lives; set => lives = value; }
		private int score = 0;
		public int Score { get => score; set => score= value; }

		private bool hasCompletedLevel = false;
		public float ScoreMultiplier { get; set; }

		public Mario(Vector2 location)
        {
            this.location = location;
			marioPowerupState = new NormalMarioPowerupState(this);
			marioMovementState = new RightIdleMarioMovementState(this);
			MarioSprite = SpriteFactory.Instance.CreateSprite(MarioFactory.Instance.GetSpriteDictionary[MarioPowerupState.GetType()][MarioMovementState.GetType()]);
            Fall = false;
            Island = true;
            IsCrouch = false;
            atTheEnd = false;
            isOnPipe = false;
            Physics = new PhysicsMario(this);

        }
        public void GoUp()
        {
          Physics.Jump();
        }
      
        public bool IsAtEnd()
        {
            return atTheEnd;
        }
		public void GoDown()
		{
            MarioMovementState.GoDown();
            IsCrouch = true;
        }
        public void GoLeft()
        {
           
            if (Island)
            {
                 MarioMovementState.GoLeft();
            }
            else
            {
                Physics.JumpLeft();
            }
        }
        public void GoRight()
        {
            
            if (Island)
            {
                MarioMovementState.GoRight();
            }
            else
            {
                Physics.JumpRight();
            }
        }
        public void Sprint()
        {
            if (Island)
            {
                Physics.Sprint();
            }
        }
        public void BeDead()
        {
            MarioPowerupState.BeDead();
            MarioMovementState.BeDead();

        }
        public void BeSuper()
        {
            MarioPowerupState.BeSuper();
        }
        public void BeNormal()
        {
            MarioPowerupState.BeNormal();
        }
        public void BeFire()
        {
            MarioPowerupState.BeFire();
        }
        public void BeStar()
        {
			GameObjectManager.Instance.Mario = new StarMarioDecorator(this);
        }
        public bool IsStarMario()
        {
			return false;
        }
        public void Update()
        {
			MarioSprite.Update();
            Physics.Update();
			if((this.location.X > GameObjectManager.Instance.EndOfLevelXPosition -MarioUtil.FlagpoleBuffer && this.location.X < GameObjectManager.Instance.EndOfLevelXPosition + MarioUtil.FlagpoleBuffer) && !hasCompletedLevel)
			{
				hasCompletedLevel = true;
                ScoringSystem.Instance.AddPointsForRestTime();
                if (MarioPowerupState is NormalMarioPowerupState)
                    GameObjectManager.Instance.GameObjectList.SetSingleton(typeof(IMario),new SlideDownFlagDecorator(this, new Vector2(this.location.X, MarioUtil.HeightOfFloor)));
                else
                    GameObjectManager.Instance.GameObjectList.SetSingleton(typeof(IMario), new SlideDownFlagDecorator(this, new Vector2(this.location.X, MarioUtil.HeightOfFloor-MarioUtil.MarioHeight)));

                atTheEnd = true;
			}
            if (isOnPipe)
            {
                location.Y++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            MarioSprite.Draw(spriteBatch, location);
        }
		public bool IsActive()
        {
			return MarioPowerupState.IsActive();
        }
       
        public void SetIsLand(bool land)
        {
            if (land)
                Island = true;
            else
                Island = false;
        }
       
        public void NoInput()
        {
            MarioMovementState.NoInput();
            if(!(MarioPowerupState is DeadMarioPowerupState))
            Physics.NotJump();
            IsCrouch = false;
        }
            
        public void ThrowProjectile()
        {
           
                MarioPowerupState.ThrowProjectile();
        }

        
       
		public void TakeDamage()
		{
			SoundManager.Instance.PlaySoundEffect("takeDamage");
			MarioPowerupState.TakeDamage();
           
        }
        public void Draw(SpriteBatch spriteBatch, Color c)
		{
			MarioSprite.Draw(spriteBatch, location,c);
		}

        public void SetFalling(bool fallState)
        {
            Fall = fallState;
        }

        public bool IsJump()
        {
            if (MarioMovementState is LeftJumpingMarioMovementState||
                MarioMovementState is RightJumpingMarioMovementState)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
