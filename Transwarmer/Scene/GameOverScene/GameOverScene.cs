using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Tutorial.Utility;
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
			RegisterDisposeOnExit (textureInfo);
			var sprite = new SpriteUV (textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			
			AddChild (sprite);
			
			Camera = new Camera2D (Director.Instance.GL, Director.Instance.DrawHelpers);
			Camera.SetViewFromViewport ();

			ScheduleUpdate(2);
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			if(  Input2.GamePad0.Start.Down )
			{
				Director.Instance.ReplaceScene(new TitleScene());
			}
		}
	}
}
