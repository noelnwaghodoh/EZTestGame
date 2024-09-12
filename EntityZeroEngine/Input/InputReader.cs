using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Input
{
	public static class InputReader
	{
	   public static int[] kBDirBuffer = new int[4];
	   public static Directions currentDirection;

	   public static int[] buffer = new int[60];
		public static int bufferSize = 60;

	   static bool checkArray(int i)
		{
			return kBDirBuffer[i] > 0;

		}
	   public static void Update()
		{
			

			if (KeyboardInput.IsKeyDown(Keys.W))
			{
				kBDirBuffer[0]++;
				//Debug.Print("We are pressing W: {0} frames, A: {1}, S: {2}, D: {3}", kBDirBuffer[0], kBDirBuffer[1], kBDirBuffer[2], kBDirBuffer[3]);

			}
			if (KeyboardInput.IsKeyDown(Keys.A))
			{
				kBDirBuffer[1]++;
				//Debug.Print("We are pressing W: {0} frames, A: {1}, S: {2}, D: {3}", kBDirBuffer[0], kBDirBuffer[1], kBDirBuffer[2], kBDirBuffer[3]);
			}
			if (KeyboardInput.IsKeyDown(Keys.S))
			{
				kBDirBuffer[2]++;

				//Debug.Print("We are pressing W: {0} frames, A: {1}, S: {2}, D: {3}", kBDirBuffer[0], kBDirBuffer[1], kBDirBuffer[2], kBDirBuffer[3]);
			}
			if (KeyboardInput.IsKeyDown(Keys.D))
			{
				kBDirBuffer[3]++;
				//Debug.Print("We are pressing W: {0} frames, A: {1}, S: {2}, D: {3}", kBDirBuffer[0], kBDirBuffer[1], kBDirBuffer[2], kBDirBuffer[3]);
			}

			if (KeyboardInput.isKeyUp(Keys.W))
			{
				Debug.Print("We Released W");
				kBDirBuffer[0] = 0;
			}
			if (KeyboardInput.isKeyUp(Keys.A))
			{
				//Debug.Print("We Released A");
				kBDirBuffer[1] = 0;

			}
			if (KeyboardInput.isKeyUp(Keys.S))
			{
				

				kBDirBuffer[2] = 0;


			}
			if (KeyboardInput.isKeyUp(Keys.D))
			{
			
				kBDirBuffer[3] = 0;
			}

			if (KeyboardInput.IsKeyPressed(Keys.W))
			{
				Debug.Print("We pressed W");

			}
			if (KeyboardInput.IsKeyPressed(Keys.A))
			{
				//Debug.Print("We pressed A");

			}
			if (KeyboardInput.IsKeyPressed(Keys.S))
			{
				

			}
			if (KeyboardInput.IsKeyPressed(Keys.D))
			{
				//Debug.Print("We pressed D");

			}


			if (checkArray(2) && checkArray(1) && !checkArray(0) && !checkArray(3))
			{ currentDirection = Directions.Numpad_1; }
			if (checkArray(2) && !checkArray(1) && !checkArray(0) && !checkArray(3))
			{	currentDirection = Directions.Numpad_2;}
			if (checkArray(2) && checkArray(3) && !checkArray(0) && !checkArray(1))
			{ currentDirection = Directions.Numpad_3;  }
			if (checkArray(1) && !checkArray(2) && !checkArray(3) && !checkArray(0))
			{ currentDirection = Directions.Numpad_4;  }
			if(!checkArray(0) && !checkArray(1) && !checkArray(2) && !checkArray(3))
			{ currentDirection = Directions.Numpad_5;}
			if(!checkArray(0) && !checkArray(1) && !checkArray(2) && checkArray(3))
			{ currentDirection = Directions.Numpad_6;  }
			if (checkArray(0) && checkArray(1) && !checkArray(2) && !checkArray(3))
			{ currentDirection = Directions.Numpad_7;  }
			if (checkArray(0) && !checkArray(1) && !checkArray(2) && !checkArray(3))
			{ currentDirection = Directions.Numpad_8;  }
			if (checkArray(0) && checkArray(3) && !checkArray(1) && !checkArray(2))
			{ currentDirection = Directions.Numpad_9;  }





			buffer[Globals.FrameCount % bufferSize] = (int)currentDirection;



			//Debug.Print(buffer[Globals.FrameCount % bufferSize].ToString());

			
            

		}


		public static bool CheckSequence(int[] sequence, int maxDuration)
		{
			int w = sequence.Length - 1;

			for (int i = 0; i < maxDuration; ++i)
			{
				int direction = buffer[(Globals.FrameCount - i + bufferSize) % bufferSize];

				if (direction == sequence[w])
					--w;
				if (w == -1)
					return true;
			}

			return false;
		}

		

		static int reverseInput(int w)
		{
			int x = 3 * (int)((w - 1) / 3);
			return x + 4 - (w - x);
		}
	}



	public enum Directions
	{
		Numpad_1 = 1,
		Numpad_2 = 2,
		Numpad_3 = 3,
		Numpad_4 = 4,
		Numpad_5 = 5,
		Numpad_6 = 6,
		Numpad_7 = 7,
		Numpad_8 = 8,
		Numpad_9 = 9
	}

	public class InputElement
	{
		public int direction;



	}



}