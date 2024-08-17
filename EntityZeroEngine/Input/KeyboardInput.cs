using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Input
{
	public static class KeyboardInput
	{
		private static KeyboardState currentKeyboard;
		private static KeyboardState previousKeyboard;

		private static int[] _keycodes;
		private static bool[] _keysPressed;
		private static bool[] _keysDown;
		private static bool[] _keysUp;

	    public static void Initialize()
		{

			_keycodes = Enum.GetValues(typeof(Keys)).Cast<int>().ToArray();
			_keysPressed = new bool[_keycodes.Length];
			_keysDown = new bool[_keycodes.Length];
			_keysUp = new bool[_keycodes.Length];


		}
		
		public static void Update()
		{
			currentKeyboard = Keyboard.GetState();


			for(int i = 0; i<_keycodes.Length;i++)
			{
				Keys key = (Keys)_keycodes[i];
		        

				if(currentKeyboard.IsKeyDown(key)&& !previousKeyboard.IsKeyDown(key)){

					_keysPressed[i] = true;
				}else{
					_keysPressed[i]= false;
				}

				if (currentKeyboard.IsKeyDown(key) && previousKeyboard.IsKeyDown(key)){
					_keysDown[i] = true;
				}
				else{
					_keysDown[i]= false;
				}

				if(currentKeyboard.IsKeyUp(key) && previousKeyboard.IsKeyDown(key)) {

					_keysUp[i] = true;
				}
				else { _keysUp[i]= false; }

			}

			previousKeyboard = Keyboard.GetState();
		}

		public static bool IsKeyPressed(Keys key)
		{
			int i = Array.FindIndex(_keycodes, x => x == (int)key);
			return _keysPressed[i];
		}

		public static bool IsKeyDown(Keys key)
		{
			int i = Array.FindIndex(_keycodes, x => x == (int)key);
			return _keysDown[i];
		}

		public static bool isKeyUp(Keys key)
		{
			int i = Array.FindIndex(_keycodes, x => x == (int)key);
			return _keysUp[i];
		}




	}
}
