using EntityZeroEngine.Collisions;
using EntityZeroEngine.EC;
using EntityZeroEngine.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Components
{
	public class CollisionBox : Component
	{


		


		public Rectangle collisionBox;

		public event EventHandler<CollisionEventArgs> onCollision;

		public List<Rectangle> colliders;

		public override void Initialize(Entity E)
		{
			//Tilemap collisionGrid = new Tilemap();

			base.Initialize(E);
			//object tilesGrid = E.S.GetType().GetField("colliderGrid").GetValue(collisionGrid);

		
			//Debug.Print(tilesGrid.ToString());


		}

		public override void Update(GameTime gametime)
		{
			collisionBox.X = E.position.ToPoint().X - E.origin.X;

			collisionBox.Y = E.position.ToPoint().Y - E.origin.Y; 



		}

		void HandleCollisions(Rectangle[] r)
		{
			Debug.Print("YO!");

			foreach (var colliider in r)
			{


			}
		}

	}
}
