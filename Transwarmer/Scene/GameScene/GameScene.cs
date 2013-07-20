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
			
			InputController Input = new InputController();
			Scheduler.Instance.ScheduleUpdateForTarget (Input, 2, false);
			
			var fireNode = new FireNode ();
			Scheduler.Instance.ScheduleUpdateForTarget (fireNode, 2, false);
			
			cameraManager = new CameraManager (this.Camera2D);
			playerNode = new PlayerNode () {cameraManager = cameraManager, Input = Input};
			AddChild (new StaticBackground ());
			AddChild (new BackgroundNode ());
			AddChild (playerNode);
			AddChild (fireNode);
		}
	}
}
