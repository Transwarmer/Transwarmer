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
	public class ClearScene : Scene
	{
		
		public ClearScene ()
		{
			var texture = new Texture2D("Application/Assets/images/end_image.png", false);
			var textureInfo = new TextureInfo(texture);
			this.RegisterDisposeOnExit (textureInfo);
			
			var sprite = new SpriteUV(){ TextureInfo = textureInfo};
			
			sprite.Quad.S = new Vector2(30,18);
			
			sprite.CenterSprite(new Vector2(0.5f,0.5f));
			
			AddChild(sprite);
			
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

