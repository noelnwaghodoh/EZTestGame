using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityZeroEngine.Systems
{
	public class SceneManager
	{


		public Stack<IScene> SceneStack;

		public SceneManager() {
			SceneStack = new();
		}


		public void AddScene(IScene scene)
		{
			scene.Load();
			SceneStack.Push(scene);
		}

		public void RemoveScene(IScene scene)
		{
			SceneStack.Pop();
		}
		public IScene GetCurrentScene()
		{
			return SceneStack.Peek();
		}

	}
}
