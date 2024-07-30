using AsepriteDotNet.Aseprite;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Aseprite;
using AsepriteDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityZeroEngine.Ogmo;

namespace EntityZeroEngine.Tiles
{

	public class Tilemap
	{
		public MonoGame.Aseprite.TextureAtlas tilesetFile { get; set; }
		public AsepriteFile asepriteFile { get; set; }


		public MonoGame.Aseprite.Sprite[] tileset;

		public Point tileSize { get; set; }


		/* This is a grid of rectangles which don't necessarily have any sprites attached to them.
		 * They could just be a grid of colliders for example. */
		public Rectangle[][] tilesGrid { get; set; }


		// Funky fresh constructor for setting the tile size. It uses a point so that you can have rectangular tiles with a height that's different from width.
		public Tilemap(Point tileSize)
		{
			this.tileSize = tileSize;
		}
		public Tilemap() { }

		

		//It takes an aseprite file and makes it into an array of Sprites that's stored in tileset[] , you're meant to use this if your Tilemap is visual
		public void createTileset(AsepriteFile aseprite)
		{
			asepriteFile = aseprite;
			tilesetFile = aseprite.CreateTextureAtlas(Globals.Graphics);
			tileset = new MonoGame.Aseprite.Sprite[asepriteFile.FrameCount];
			for (int i = 0; i < asepriteFile.FrameCount; i++)
			{
				MonoGame.Aseprite.Sprite sprite = tilesetFile.CreateSprite(string.Format("{0} {1}", asepriteFile.Name, i));
				tileset[i] = sprite;
				Debug.Print(tileset[i].Name);
			}
		}

		// It takes a jagged array of strings and creates tiles where there are "1"s. Search for grid2D in  Stage 0.json to see the array its reading in-game. 
		public void CreateTilesGrid(string[][] grid2D)
		{

			tilesGrid = new Rectangle[grid2D.Length][];
			for (int j = 0; j < grid2D.Length; j++)
			{
				Rectangle[] tilesRow = new Rectangle[grid2D[j].Length];
				for (int i = 0; i <= grid2D[j].Length; i++)
				{
					if (i == grid2D[j].Length)
					{
						tilesGrid[j] = tilesRow;
					}
					else
					{
						if (grid2D[j][i] == "1")
						{

							tilesRow[i] = new Rectangle(i * tileSize.X, j * tileSize.Y, tileSize.X, tileSize.Y);
							Debug.Print(tilesRow[i].ToString());
						}
					}
				}
			}
		}

		//It takes a jagged array of ints and draws different tiles based on their values. If you search for data2D in Stage0.json you'll see an array with a bunch of ints ranging from -1 to 1. 
		// The -1s are empty space, the 0s are  all the blue tiles and the 1s are the grey tiles. It's based off their order in the tileset. The blue comes before grey so it's tileset[0] while grey is tileset[1]. 
		// There are other tiles in greybox which I didn't use so that's why the range is so small. 
		public void DrawSprites(int[][] data, SpriteBatch spriteBatch)
		{
			for (int j = 0; j < data.Length; j++)
			{

				for (int i = 0; i < data[j].Length; i++)
				{
					if (data[j][i] > -1)
					{

						tileset[data[j][i]].Draw(spriteBatch, new Vector2((i * tileSize.X), (j * tileSize.Y)));
					}


				}
			}

		}

		// This function draws a non-visual grid just incase you wanted to see it for some reason. 
		public void Draw(SpriteBatch spriteBatch, GraphicsDevice device)
		{

			Texture2D blankTexture = new Texture2D(device, 1, 1);
			blankTexture.SetData<Color>(new Color[] { Color.White });
			foreach (var tileArray in tilesGrid)
			{
				foreach (var tile in tileArray)
				{
					spriteBatch.Draw(blankTexture, destinationRectangle: tile, Color.White);

				}


			}
		}
	}
}
