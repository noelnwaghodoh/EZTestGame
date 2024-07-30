using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine
{
	public class RectangleF
	{
		float x, y, width, height;

		float Top => y;
		float Left => x;
		float Right => x + width;
		float Bottom => y + height;

	


		public RectangleF(float x, float y, float width, float height) { 
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;

			 
		}
		

	}
}
