using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.EC
{
	public class Component
	{
		public Entity E { get; set; } // This stores that owns this component

		public virtual void Initialize(Entity E)
		{
			this.E = E;
		}

		public virtual void Update(GameTime gametime) {
		
		}

		
	}
}
