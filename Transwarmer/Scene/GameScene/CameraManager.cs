using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class CameraManager
	{
		private Camera2D camera;
		
		public CameraManager (Camera2D camera)
		{
			this.camera = camera;
		}
		
		public void OnPlayerPositionChanged (float position) {
			this.camera.SetViewFromHeightAndBottomLeft (544.0f, new Vector2(position, 0));
		}
	}
}

