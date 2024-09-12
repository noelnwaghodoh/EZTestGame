using EntityZeroEngine.Components;
using EntityZeroEngine.EC;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Systems
{
    public interface IState
	{

		public StateMachine SM { get; set; }
		public void Initailize(StateMachine SM)
		{
				 this.SM = SM;
		}
		public  void Update(GameTime gameTime)
		{
		  
		}
		
	}

	
}
