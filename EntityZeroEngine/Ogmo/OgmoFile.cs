using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;

namespace EntityZeroEngine.Ogmo
{
	public class OgmoFile
	{
		public string ogmoVersion { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public int offsetX { get; set; }
		public int offsetY { get; set; }
		public List<Layer> layersList { get; set; }
		public List<OgmoTileLayer> tileLayers { get; set; }
		public List<OgmoEntityLayer> entityLayers { get; set; }
		public List<OgmoGridLayer> gridLayers { get; set; }



		public OgmoFile(string filename)
		{
			Console.WriteLine(filename);
			var jsonString = File.ReadAllText(filename);
			//this.offsetX = JsonSerializer.Deserialize<OgmoFile>(jsonString).offsetX;
			//



			using var doc = JsonDocument.Parse(jsonString);
			ogmoVersion = doc.RootElement.GetProperty("ogmoVersion").GetString();
			width = doc.RootElement.GetProperty("width").GetInt16();
			height = doc.RootElement.GetProperty("height").GetInt16();
			offsetX = doc.RootElement.GetProperty("offsetX").GetInt16();
			offsetY = doc.RootElement.GetProperty("offsetY").GetInt16();

			layersList = new List<Layer>();
			tileLayers = new List<OgmoTileLayer>();
			entityLayers = new List<OgmoEntityLayer>();
			gridLayers = new List<OgmoGridLayer>();

			//This isolates  the "layers" array of objects
			JsonElement layers = doc.RootElement.GetProperty("layers");
			Debug.Print(layers.ToString());

			foreach (var layerElement in layers.EnumerateArray())
			{
				var name = layerElement.GetProperty("name").GetString();
				var gridCellsX = layerElement.GetProperty("gridCellsX").GetInt16();
				var gridCellsY = layerElement.GetProperty("gridCellsY").GetInt16();
				layersList.Add(new Layer());


				JsonElement data2d = new JsonElement();
				if (layerElement.TryGetProperty("data2D", out data2d))
				{
					OgmoTileLayer tileLayer = new OgmoTileLayer();


					//Debug.Print(data2d[0][10].ToString());
					tileLayer.name = name; ;
					tileLayer.gridCellCount = new Point(gridCellsX, gridCellsY);


					tileLayer.data2d = new int[gridCellsY-1][];


					for (int j = 0; j < gridCellsY-1; j++)
					{
						Debug.Write(System.Environment.NewLine);
						int[] row = new int[gridCellsX];
						for (int i = 0; i <= gridCellsX; i++)
						{
							if (i == gridCellsX)
							{
								tileLayer.data2d[j] = row;
								foreach (var cell in tileLayer.data2d[j])
								{
									Debug.Write(cell+ " ");

								}
							}
							else row[i] = data2d[j][i].GetInt32();
						}
					}
					//Debug.Print(tileLayer.data2d.ToString());
					tileLayers.Add(tileLayer);


				}
				//Debug.Print(name);


				JsonElement entities = new JsonElement();
				if (layerElement.TryGetProperty("entities", out entities))
				{


					Debug.Print(layerElement.GetProperty("name").GetString());
					OgmoEntityLayer entityLayer = new OgmoEntityLayer();
					entityLayer.name = name;
					entityLayer.entities = new List<OgmoEntity>();
					foreach (var entityElement in entities.EnumerateArray())
					{

						OgmoEntity entity1 = new OgmoEntity();

						entity1.name = entityElement.GetProperty("name").GetString(); ;
						entity1.position = new Point(entityElement.GetProperty("x").GetInt16(),
							entityElement.GetProperty("y").GetInt16());
						entity1.origin = new Point(entityElement.GetProperty("originX").GetInt16(),
							entityElement.GetProperty("originY").GetInt16());

						entityLayer.entities.Add(entity1);

						Debug.Print(entity1.name);
						Debug.Print(entity1.origin.X.ToString() + "," + entity1.origin.Y.ToString());

					}
					entityLayers.Add(entityLayer);
					
				}


				JsonElement grid2D = new JsonElement();
				if (layerElement.TryGetProperty("grid2D", out grid2D))
				{
					OgmoGridLayer gridLayer = new OgmoGridLayer();
					Debug.Print(gridLayer.name);
					gridLayer.name = name;
					gridLayer.gridCellCount = new Point(gridCellsX, gridCellsY);	
					
					gridLayer.grid2d = new string[gridCellsY-1][];


					for (int j = 0; j < gridCellsY-1; j++)
					{

						string[] row = new string[gridCellsX];
						for (int i = 0; i <= gridCellsX; i++)
						{
							if (i == gridCellsX)
							{
								gridLayer.grid2d[j] = row;



							}
							else
							{
								row[i] = grid2D[j][i].GetString();
								//Debug.Print(row[i]);

							}
						}
					}
					gridLayers.Add(gridLayer);
				}

			}










		}


		public OgmoTileLayer GetTileLayerByName(string name)
		{

			//query the layers list  for  a layer with a matching name then return it

			OgmoTileLayer  otl = this.tileLayers.Find(layer  => layer.name == name);
			return otl;

		}
		public OgmoGridLayer GetGridLayerByName(string name)
		{

			//query the layers list  for  a layer with a matching name then return it

			OgmoGridLayer ogl = this.gridLayers.Find(layer => layer.name == name);
			return ogl;

		}
		public OgmoEntityLayer GetEntityLayerByName(string name)
		{

			//query the layers list  for  a layer with a matching name then return it

			OgmoEntityLayer oel = this.entityLayers.Find(layer => layer.name == name);
			return oel;

		}


	}

	public class Layer
	{
		public string name { get; set; }
		public int _eid { get; set; }
		public Point offset { get; set; }
		public Point gridCellSize { get; set; }
		public Point gridCellCount { get; set; }
	}

	public class OgmoTileLayer : Layer
	{
		public int[][] data2d;
	}
	public class OgmoEntityLayer : Layer
	{
		//
		public List<OgmoEntity> entities;


		
	}

	public class OgmoGridLayer : Layer
	{
		public string[][] grid2d;

	}

	public class OgmoDecalLayer : Layer
	{

		public List<OgmoDecal> Decals;

	}

	public class OgmoEntity
	{
		public string name { get; set; }
		public int eid { get; set; }
		public Point position { get; set; }
		public Point origin { get; set; }
	}

	public class OgmoDecal
	{
		public Point position;
		public Vector2 origin;


	}

	

	public struct LayerDefinition
	{




	}
}
