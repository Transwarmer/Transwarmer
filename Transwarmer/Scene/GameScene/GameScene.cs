using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core;

namespace Transwarmer
{
	public class GameScene : Scene
	{
		public GameScene ()
		{
			this.Camera.SetViewFromViewport ();
			AddChild (new BackgroundNode ());
			AddChild (new PlayerNode ());
		}
	}
}
