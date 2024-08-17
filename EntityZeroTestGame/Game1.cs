using EntityZeroEngine;
using EntityZeroEngine.Systems;
using EntityZeroTestGame.Scenes;
using EntityZeroTestGame.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;


namespace EntityZeroTestGame
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;



		private SceneManager sceneManager;

        private int nativeWidth = 320; private int nativeHeight = 180;


		private RenderTarget2D _renderTarget;
		private Rectangle _renderDestination;


		private int _framecount =0;


		public Game1()
		{



			_graphics = new GraphicsDeviceManager(this);
			
			
			sceneManager = new SceneManager();
			Content.RootDirectory = "Content";

			Globals.FrameCount = 0;

			_graphics.PreferredBackBufferWidth = 960; _graphics.PreferredBackBufferHeight = 540;


			
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
			
			CalculateRenderDestination();
			EntityZeroEngine.Input.KeyboardInput.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			Globals.Graphics = _graphics.GraphicsDevice;
			AssetData.LoadAsepriteFiles();
			sceneManager.AddScene(new Scene_Stage_0(Content,GraphicsDevice));
			// TODO: use this.Content to load your game content here


			_renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, nativeWidth, nativeHeight);
		}


		private void CalculateRenderDestination()
		{

			Point size = GraphicsDevice.Viewport.Bounds.Size;

			float scaleX = (float)size.X / _renderTarget.Width;
			float scaleY = (float)size.Y / _renderTarget.Height;

			float scale = Math.Min(scaleX, scaleY);

			_renderDestination.Width = (int)(_renderTarget.Width * scale);
			_renderDestination.Height = (int)(_renderTarget.Height * scale);


			_renderDestination.X = (size.X - _renderDestination.Width) / 2;
			_renderDestination.Y = (size.Y - _renderDestination.Height) / 2;
		}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			EntityZeroEngine.Input.KeyboardInput.Update();
			EntityZeroEngine.Input.InputReader.Update();

			sceneManager.GetCurrentScene().Update(gameTime);
			Globals.FrameCount++;
		//	Debug.Print(Globals.FrameCount.ToString());



			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);


			GraphicsDevice.SetRenderTarget(_renderTarget);
			// TODO: Add your drawing code here

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);

			sceneManager.GetCurrentScene().Draw(_spriteBatch);
			_spriteBatch.End();

			GraphicsDevice.SetRenderTarget(null);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			_spriteBatch.Draw(_renderTarget, _renderDestination, Color.White);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
