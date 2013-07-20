using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class CameraManager
	{
		public CameraManager (Camera2D camera)
		{
			camera.SetViewFromHeightAndBottomLeft (544.0f, new Vector2(-100.0f, 0));
		}
	}
}

