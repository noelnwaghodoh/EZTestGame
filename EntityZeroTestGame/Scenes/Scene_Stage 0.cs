using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityZeroEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EntityZeroTestGame.Scenes
{
	public class Scene_Stage_0: IScene
	{
		public ContentManager contentManager;
		public Texture2D stage;
		
		public Scene_Stage_0(ContentManager contentManager)
		{
			this.contentManager = contentManager;

		}



		public void Load() // This load method is where the scene can get the data it needs from ogmo or by hand or whatever
		{

			stage = contentManager.Load<Texture2D>("Stage_0");


		}

		public void Update(GameTime gameTime)
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(stage, Vector2.Zero, Color.White);
		}


	}
}
