using EntityZeroEngine.Components;
using EntityZeroEngine.EC;
using EntityZeroEngine.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityZeroTestGame.Entities;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace EntityZeroTestGame
{
	
	public class IdleState: IState
	{

		public StateMachine SM {  get; set; }	
		public string name {  get; set; }

		public Player player;
		


		public void Update(GameTime gameTime)
		{
			
		 
		}

	}
	public class WalkState : IState
	{

		public StateMachine SM { get; set; }
		public string name { get; set; }



		public void Update(GameTime gameTime)
		{

			
		}

	}
}
