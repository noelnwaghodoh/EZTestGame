using EntityZeroEngine.Ogmo;
using EntityZeroEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityZeroEngine.EC
{
	public class Entity
	{
		public string name;
		public Vector2 position;
		public Point origin;
		public Scene S;

		private List<Component> components;
		public List<Component> Components
		{
			get { return components; }
			set { components = value; }
		}



		public virtual void Create(Scene scene)
		{
			S = scene;	
			scene.Entities.Add(this);
			components = new List<Component>();
			
		}
		public virtual void Update(GameTime gametime) {
		//	Debug.Print("Updating Components");
			foreach (var component in Components)
			{

				component.Update(gametime);
			}
		}

		public virtual void Draw (SpriteBatch spriteBatch)
		{
		}

		public Entity(OgmoEntity ogmoEntity)
		{
			name = ogmoEntity.name;
			position = ogmoEntity.position.ToVector2();
			origin = ogmoEntity.origin;

		}
		public Entity() { 
		}

		public Component AddComponent(Component C)
		{
			components.Add(C);
			C.Initialize(this);
			return C;
		}
	}
}
