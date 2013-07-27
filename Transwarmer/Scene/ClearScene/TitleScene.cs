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
	public class TitleScene : Scene
	{
		public TitleScene ()
		{
			var texture = new Texture2D("Application/Assets/images/title_image.png", false);
			var textureInfo = new TextureInfo(texture);
			this.RegisterDisposeOnExit (textureInfo);
			var sprite = new SpriteUV(){ TextureInfo = textureInfo};
			sprite.Quad.S = textureInfo.TextureSizef;
			
			Camera = new Camera2D (Director.Instance.GL, Director.Instance.DrawHelpers);
			Camera.SetViewFromViewport ();

			AddChild(sprite);
			ScheduleUpdate(2);
			
			// for test; fireWall and fireleaf_one become noise. other images are not.
			//generateFireleafSprite();
		}
		
		private void generateFireleafSprite ()
		{
			var texture = new Texture2D ("/Application/Assets/images/fireleaf_one.png", false);
			var textureInfo = new TextureInfo (texture);
			this.RegisterDisposeOnExit (textureInfo);
			var sprite = new SpriteUV (textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			AddChild (sprite);
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			if( Input2.GamePad0.Start.Release )
			{
				UnscheduleUpdate();
				Director.Instance.ReplaceScene(new GameScene());
				
			}
		}
	}
}

