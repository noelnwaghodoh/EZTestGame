using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Aseprite;

namespace EntityZeroEngine.Animation
{
     public class Animation
	{
		List<Sprite> regions;
		Sprite currentSprite;


		int currentFrame;
		int totalFrameCount;

		bool active;

		public Animation(int startFrame , int endFrame, TextureAtlas spriteSheet) { 
		 
			regions = new List<Sprite>();
			for (int i = startFrame ; i < endFrame ; i++)
			{

				regions.Add(new Sprite(spriteSheet.GetRegion(i).Name, spriteSheet.GetRegion(i)));
			}
			
		}
		
		public void Update()
		{ 
			

		}

		public void Draw()
		{

		}

	}
}
