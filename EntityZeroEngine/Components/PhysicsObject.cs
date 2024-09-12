using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityZeroEngine.EC;
using EntityZeroEngine.Collisions;
using System.Diagnostics;

namespace EntityZeroEngine.Components
{
	public class PhysicsObject : Component
	{


		int mass;

		// For now this is like main movement vector
		// The way I think it should work is that other forces can act on each other by multiplying this
		public Vector2 velocity { get; set; }
		

		public Vector2 acceleration;

		public CollisionBox component_CollisionBox { get; set; }


		public override void Initialize(Entity E)
		{
			base.Initialize(E);
			component_CollisionBox = E.GetComponent<CollisionBox>();
		}

		public override void Update(GameTime gameTime)
		{
			// 

			velocity += acceleration;
			E.position += velocity;
			HandleCollisions();
			
			
			//	Debug.Print("Updating Data");
		}

		void HandleCollisions()
		{
			if (component_CollisionBox != null)
			{
				foreach (var collider in component_CollisionBox.colliders)
				{
					if (collider != component_CollisionBox.collisionBox && component_CollisionBox.collisionBox.Intersects(collider) )
					{
						acceleration = new Vector2(0, 0);



						velocity = new Vector2(0, 0);
						float ID = Collision.IntersectionDepth(component_CollisionBox.collisionBox, collider).Y;


						Debug.Print("The collision depth y is " + ID);

						component_CollisionBox.collisionBox.Y += (int)ID;
						E.position.Y += ID;

					}
				}

			}
		}
		

	}
}
