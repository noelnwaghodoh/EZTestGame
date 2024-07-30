using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityZeroEngine.EC;

namespace EntityZeroEngine.Components
{
	public class PhysicsObject : Component
	{


		int mass;

		// For now this is like main movement vector
		// The way I think it should work is that other forces can act on each other by multiplying this
		public Vector2 velocity { get; set; }
		

		public Vector2 acceleration;




		public override void Update(GameTime gameTime)
		{
			// 

			velocity += acceleration;
			E.position += velocity;
			
			//	Debug.Print("Updating Data");
		}
		public void Accelerate(Point acceleration)
		{
			velocity = new Vector2(velocity.X + acceleration.X, velocity.Y + acceleration.Y); ;
		}


	}
}
