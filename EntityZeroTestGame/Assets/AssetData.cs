using AsepriteDotNet.Aseprite;
using AsepriteDotNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using EntityZeroEngine.Ogmo;

namespace EntityZeroTestGame.Assets
{
	internal static class AssetData
	{
		

		public static Dictionary<String, AsepriteFile> AsepriteFiles;
		public static Dictionary<String, OgmoFile> OgmoFiles;

		public static String AsepriteFileDirectory = "Assets/Aseprite Files\\";
		public static String OgmoFileDirectory = "Assets/Ogmo Levels\\";
	

		public static void LoadAsepriteFiles()
		{

			AsepriteFiles = new Dictionary<string, AsepriteFile>();
			string[] filenames = Directory.GetFiles("Assets/Aseprite Files");

			// foreach filename in the AsepriteFiles Directory add the current file to the list and construct and asepritefile from it.
			//
			foreach (string AsepriteFile in filenames)
			{
				AsepriteFiles.Add(AsepriteFile, AsepriteFileLoader.FromFile(AsepriteFile));
			}
		}

		public static void LoadOgmoFiles()
		{


			OgmoFiles = new Dictionary<string, OgmoFile>();
			string[] filenames = Directory.GetFiles("Assets/Ogmo Files");

			foreach(String OgmoFile in filenames)
			{
				//OgmoFiles.Add()
			}
			
		}




	}
}
