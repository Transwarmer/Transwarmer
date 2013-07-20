using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core;

namespace Transwarmer
{
	public class GameScene : Scene
	{
		private PlayerNode playerNode;
		private CameraManager cameraManager;
		
		public GameScene ()
		{
			this.Camera.SetViewFromViewport ();
			
			// output FPS benchmark to console
			// Scheduler.Instance.ScheduleUpdateForTarget (new FPSBenchmarkNode(), 2, false);
			
			playerNode = new PlayerNode ();
			cameraManager = new CameraManager (this.Camera2D);
			AddChild (new BackgroundNode ());
			AddChild (playerNode);
		}
	}
}
