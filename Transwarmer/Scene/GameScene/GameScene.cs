using System;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class GameScene : Scene
	{
		public GameScene ()
		{
			this.Camera.SetViewFromViewport ();
			AddChild (new BackgroundNode ());
		}
	}
}
