using EntityZeroEngine.EC;
using EntityZeroEngine.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EntityZeroEngine.Components
{
	public class StateMachine :Component
	{


		public List<IState> states;

		public IState currentState;
		public override void Initialize(Entity E)
		{

			base.Initialize(E);

			states = new List<IState>();

			
		}

		public override void Update(GameTime gametime)
		{
			
			base.Update(gametime);
			currentState.Update(gametime);
		}

	}


	
}
