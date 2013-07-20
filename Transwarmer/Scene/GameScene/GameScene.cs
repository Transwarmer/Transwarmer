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
			
			Scheduler.Instance.ScheduleUpdateForTarget (new FPSBenchmarkNode(), 2, false);
			
			AddChild (new BackgroundNode ());
			AddChild (new PlayerNode ());
		}
	}
}
