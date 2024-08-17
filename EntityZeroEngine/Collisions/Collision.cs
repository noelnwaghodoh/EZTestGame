using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Collisions
{
	public class Collision
	{

		public bool isColliding(Rectangle a, Rectangle b)
		{
			return a.Right > b.Left
				 && a.Left < b.Right
				 && a.Top < b.Bottom
				 && a.Bottom > b.Top;


		}

		


		public static  Vector2 IntersectionDepth(Rectangle a, Rectangle b)
		{
			// Calculate half sizes.
			var thisHalfWidth = a.Width / 2.0f;
			var thisHalfHeight = a.Height / 2.0f;
			var otherHalfWidth = b.Width / 2.0f;
			var otherHalfHeight = b.Height / 2.0f;

			// Calculate centers.
			var centerA = new Vector2(a.Left + thisHalfWidth, a.Top + thisHalfHeight);
			var centerB = new Vector2(a.Left + otherHalfWidth, b.Top + otherHalfHeight);

			// Calculate current and minimum-non-intersecting distances between centers.
			var distanceX = centerA.X - centerB.X;
			var distanceY = centerA.Y - centerB.Y;
			var minDistanceX = thisHalfWidth + otherHalfWidth;
			var minDistanceY = thisHalfHeight + otherHalfHeight;

			// If we are not intersecting at all, return (0, 0).
			if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
				return Vector2.Zero;

			// Calculate and return intersection depths.
			float depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
			float depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
			return new Vector2(depthX, depthY);
			
		}
	}

	public class CollisionEventArgs : EventArgs
	{
		Rectangle box { get; set; }


	}
}
