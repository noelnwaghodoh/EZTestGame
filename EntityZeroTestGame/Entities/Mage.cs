using AsepriteDotNet.Aseprite;
using AsepriteDotNet.Aseprite.Types;
using EntityZeroEngine;
using EntityZeroEngine.EC;
using EntityZeroEngine.Input;
using EntityZeroEngine.Systems;
using EntityZeroTestGame.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Aseprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroTestGame.Entities
{
	public class Mage : Entity
	{

		static AsepriteFile mageFile = AssetData.AsepriteFiles[AssetData.AsepriteFileDirectory + "Mage.aseprite"];
		SpriteSheet mageSheet = mageFile.CreateSpriteSheet(Globals.Graphics, AsepriteDotNet.Processors.ProcessorOptions.Default);
		//TextureAtlas mageAtlas = mageFile.CreateTextureAtlas(Globals.Graphics
		
		int speed;

		AnimatedSprite walkUp;
		AnimatedSprite walkDown;
		AnimatedSprite walkRight;

		AnimatedSprite current;
		public override void Create(Scene scene)
		{

			base.Create(scene);

			
			origin = new Point(15, 35);

            walkUp = mageSheet.CreateAnimatedSprite("Walk_Up");
            walkDown = mageSheet.CreateAnimatedSprite("Walk_Down");
		    walkRight = mageSheet.CreateAnimatedSprite("Walk_Right");

			 current = walkUp; 
			

			Debug.Print("yo");

			speed =	2;
			

		}
		public override void Update(GameTime gametime)
		{
			
			
			if (InputReader.CheckSequence(new int[] {6},1)) // this is the same as checking if we're holding 6
			{
				position.X += speed;
				current = walkRight;
				current.Speed = 0.7;
				current.Play();
				current.FlipHorizontally = false;
				
				//Debug.Print("b");
			}
			

			if(InputReader.CheckSequence(new int[] {4}, 1))
			{
				position.X -= speed;

				Debug.Print("Call");

				current = walkRight;
				current.Speed = 0.7;
				current.FlipHorizontally = true;
				current.Play();
				
			}
			//Debug.Print(InputReader.kBDirBuffer[1].ToString());
			if(InputReader.CheckSequence(new int[] {5},1))
			{
				current.Reset();
				current.Stop();
			}



			current.Update(gametime);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			//mageSheet.TextureAtlas.GetRegion(0).Draw(spriteBatch,	new Rectangle((int)position.X,(int) position.Y, 32, 46),	Color.White) ;

			current.Draw(spriteBatch,position);
	//		
		}
	}
}
