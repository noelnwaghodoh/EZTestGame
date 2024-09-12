using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityZeroEngine;
using EntityZeroEngine.Systems;
using EntityZeroTestGame.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AsepriteDotNet;
using MonoGame.Aseprite;
using AsepriteDotNet.Aseprite;
using AsepriteDotNet.IO;
using System.Threading.Tasks.Sources;
using System.IO;
using System.Diagnostics;
using EntityZeroEngine.Ogmo;
using EntityZeroEngine.Tiles;
using EntityZeroEngine.EC;
using System.Runtime.CompilerServices;
using EntityZeroTestGame.Entities;
using EntityZeroEngine.Components;

namespace EntityZeroTestGame.Scenes
{
	public class Scene_Stage_0: Scene
	{
		public ContentManager contentManager;
		public GraphicsDevice gDevice;

		Rectangle[] CollisionTiles { get; set; }

		//private List<Decal> decals = new ();


		AsepriteFile backgroundFile;
		MonoGame.Aseprite.Sprite backgroundSprite;
		
	    Decal background = new Decal();

		OgmoFile stage0;

		EntityZeroEngine.Tiles.Tilemap visualGrid;
	   EntityZeroEngine.Tiles.Tilemap colliderGrid;

		Player player;

		Mage mage;

		 List<Rectangle> colliders = new List<Rectangle>();	


		public Scene_Stage_0(ContentManager contentManager, GraphicsDevice gDevice)
		{
			this.contentManager = contentManager;
			this.gDevice = gDevice;
			
		}



		public override void Load() // This load method is where the scene can get the data it needs from ogmo or by hand or whatever
		{
			




			Entities = new List<Entity>();

			
			backgroundFile = AsepriteFileLoader.FromFile("Assets\\Aseprite Files\\background.aseprite");
	
			backgroundSprite = backgroundFile.CreateSprite(gDevice, 0);
			backgroundSprite.Origin = new Vector2(0, 0);


		

			stage0 = new OgmoFile("Stage 0.json");


			//This is the code to create the visual tilemap
			visualGrid = new EntityZeroEngine.Tiles.Tilemap(new Point(16,16));
			visualGrid.createTileset(AssetData.AsepriteFiles[AssetData.AsepriteFileDirectory+"Greybox.aseprite"]); ;

			//This is code to create the collider tilemap
			colliderGrid = new EntityZeroEngine.Tiles.Tilemap(new Point(16, 16));
			colliderGrid.CreateTilesGrid(stage0.GetGridLayerByName("Collidables").grid2d);



			foreach(string image in Directory.GetFiles("Content\\Aseprite Files\\"))
			{
				Debug.Print("This is "+image);
				//new AsepriteFile asefile = 
			}


			player = new Player(stage0.GetEntityLayerByName("entities").entities.Find(oe => oe.name == "Player"));
			player.Create(this);


			mage = new Mage();
			mage.Create(this);


			

			foreach(Rectangle[] rectarray in colliderGrid.tilesGrid )
			{
				foreach (Rectangle r in rectarray )
				{
					if(r.IsEmpty) continue;
					colliders.Add(r);
					
				}
			}

			foreach(var e in Entities)
			{
				CollisionBox box = e.GetComponent<CollisionBox>();
			//	if( box != null )
				//colliders.Add(box.collisionBox);
			}

			//player.SetColliderList(colliders);
			foreach (var e in Entities)
			{
				CollisionBox box = e.GetComponent<CollisionBox>();
				if (box != null)
				box.colliders = colliders;


			}




			Debug.Print("done");
			//Decal decal



		}

		public override void Update(GameTime gameTime) // This method is going to be used to update all the entities in the scene
		{
			foreach(Entity entity in base.Entities)
			{
				//Debug.Print("Updaring Entities");
				entity.Update(gameTime);
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			
		     backgroundSprite.Draw(spriteBatch,new Vector2(0,0));
				visualGrid.DrawSprites(stage0.GetTileLayerByName("Tile Layer").data2d,spriteBatch);
			player.Draw(spriteBatch);
			mage.Draw(spriteBatch);
		}


	}
}
