using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Systems
{
	public class SceneManager
	{


		public Stack<Scene> SceneStack;

		public SceneManager() {
			SceneStack = new();
		}


		public void AddScene(Scene scene)
		{
			scene.Load();
			SceneStack.Push(scene);
		}

		public void RemoveScene(Scene scene)
		{
			SceneStack.Pop();
		}
		public Scene GetCurrentScene()
		{
			return SceneStack.Peek();
		}

	}
}
