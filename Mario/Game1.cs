using Game1;
using Mario.HeadUpDesign;
using Mario.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

[assembly: System.CLSCompliant(true)]

namespace Mario
{
	public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		private bool isPause;
		public bool IsPause { get => isPause; set => isPause = value; }
		private IList<IController> controllerList = new List<IController>();
		private static Game1 instance;
		public static Game1 Instance { get => instance; set => instance = value; }
        public Game1()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsPause = false;
        }
        protected override void Initialize()
        {

			base.Initialize();
			controllerList.Add(new Keyboards());
			graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            GameObjectManager.Instance.SetInitialValuesCamera();

        }

      
        protected override void LoadContent()
        {
			base.LoadContent();
			spriteBatch = new SpriteBatch(GraphicsDevice);
            SoundManager.loadcontent(Content);
            GameObjectManager.Instance.LoadContent();
        }

      
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
                Timer.TimerCheckingTime(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
            GameObjectManager.Instance.CurrentGameTime = gameTime;
            GameObjectManager.Instance.Update();
                base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GameObjectManager.Instance.CurrentGameTime = gameTime;
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, GameObjectManager.Instance.CameraMario.Transform);
            ChangeColor();
            GameObjectManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void Reset()
        {
            GameObjectManager.Instance.SetInitialValuesCamera();
            Timer.ResetTimer();
            LevelCounter.Instance.ResetLevel();
            LoadContent();
            LifeCounter.Instance.ResetLife();
            ScoringSystem.Instance.ResetScore();
            CoinSystem.Instance.ResetCoin();

        }
        private void ChangeColor()
        {
            if (GameObjectManager.Instance.Mario.Position.X > GameUtil.UndergroundPosition)
            GraphicsDevice.Clear(Color.Black);
            else if (GameObjectManager.Instance.Mario.Position.X < GameUtil.UndergroundPosition)
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
