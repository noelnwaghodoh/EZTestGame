using EntityZeroEngine.Collisions;
using EntityZeroEngine.Components;
using EntityZeroEngine.EC;
using EntityZeroEngine.Systems;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using MonoGame.Aseprite.Utils;
using EntityZeroEngine.Ogmo;
using EntityZeroTestGame.Assets;
using AsepriteDotNet.Aseprite;
using MonoGame.Aseprite;
using EntityZeroEngine;

namespace EntityZeroTestGame.Entities
{
    public class Player:Entity
	{



		//IState currentState = new IdleState();
	
		PhysicsObject physicsObject = new PhysicsObject();
		CollisionBox collisionBox = new CollisionBox();

		List<Rectangle> colliders = new List<Rectangle> ();


		static AsepriteFile playerfile = AssetData.AsepriteFiles[AssetData.AsepriteFileDirectory +"Atlas_Entity_0.aseprite"];
		Sprite playerSprite = playerfile.CreateSprite(Globals.Graphics, 0);
		

		
		public Texture2D texture = new Texture2D(Globals.Graphics, 1, 1);
		

		public override void Create(Scene scene)
		{

				 collisionBox.collisionBox = new Rectangle(position.ToPoint().X-origin.X, position.ToPoint().Y-origin.Y,21 , 36);

			playerSprite.Origin = new Vector2 (origin.X, origin.Y);
			texture.SetData<Color>(new Color[] { Color.Lavender });
			
		   base.Create(scene);
			AddComponent(collisionBox);
			AddComponent(physicsObject);
			physicsObject.velocity = new Vector2(0, 1f);
			physicsObject.acceleration = new Vector2(0, 0.06f);



			




		}

		
	

		bool grounded = false; // A



		public override void Update(GameTime gametime)
		{
			
			base.Update(gametime);

			//if (EntityZeroEngine.Input.InputReader.CheckSequence(new int[4] { 6,5,6,5},10))
			//{
				//Debug.Print("Dashing");
			//}

			
			
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			playerSprite.Draw(spriteBatch, new Vector2(position.X,position.Y));
			//spriteBatch.Draw(texture, collisionBox.collisionBox, new Color(0, 0, 0, 130));

			//base.Draw(spriteBatch);
		}
		public Player(OgmoEntity ogmoEntity)
		{
			name = ogmoEntity.name;
			position = ogmoEntity.position.ToVector2();
			origin = ogmoEntity.origin;
		}

		
		enum CurrentState
		{
			Idle, 
			Walking
		}

		
	}
}
