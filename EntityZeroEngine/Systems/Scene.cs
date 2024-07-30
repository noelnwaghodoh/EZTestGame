using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EntityZeroEngine.EC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace EntityZeroEngine.Systems
{

	public class Scene
	{

		private List<Entity> entities;

		public List<Entity> Entities
		{
			get { return entities; }
			set { entities = value; }
		}

		//
		//for (int i = 0; i < ogmoFile.entityLayers[0].entities.Count; i++)
		//{
		//	Entity current = new Entity(ogmoFile.entityLayers[0].entities[i]);
		//	Entities.Add(current);
		//}

		public virtual void Load()
	    {

	    }
		public virtual void Update(GameTime gameTime)
		{

		}
		public virtual void Draw(SpriteBatch spriteBatch)
		{

		}


	}
}