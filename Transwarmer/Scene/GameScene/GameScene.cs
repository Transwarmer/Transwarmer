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
			this.Camera2D.SetViewX (new Vector2(480.0f, 272.0f), new Vector2(0.0f, 0.0f));
			AddChild (new BackgroundNode ());
		}
	}
}
