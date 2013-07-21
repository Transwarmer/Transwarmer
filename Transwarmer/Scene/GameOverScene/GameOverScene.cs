using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class GameOverScene : Scene
	{
		public GameOverScene ()
		{
			var texture = new Texture2D ("/Application/Assets/images/dead_scene.png", false);
			var textureInfo = new TextureInfo (texture);
			var sprite = new SpriteUV (textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			
			AddChild (sprite);
			
			Camera = new Camera2D (Director.Instance.GL, Director.Instance.DrawHelpers);
			Camera.SetViewFromViewport ();
			
			Scheduler.Instance.ScheduleUpdateForTarget (this, 3, false);
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			var gamepad = GamePad.GetData(0);
			if (
			Director.Instance.ReplaceScene (new GameScene());
		}
	}
}

