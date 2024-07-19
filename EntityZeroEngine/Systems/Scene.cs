using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace EntityZeroEngine.Systems
{
	public interface IScene
	{
		//public List<Entity> Entities;




		//Entities = new List<Entity>();
		//for (int i = 0; i < ogmoFile.entityLayers[0].entities.Count; i++)
		//{
		//	Entity current = new Entity(ogmoFile.entityLayers[0].entities[i]);
		//	Entities.Add(current);
		//}

		public void Load();
		public void Update(GameTime gameTime);
		public void Draw(SpriteBatch spriteBatch);


	}
}
