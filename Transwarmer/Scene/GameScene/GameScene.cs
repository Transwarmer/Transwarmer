using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class GameScene : Scene
	{
		private PlayerNode playerNode = null;
		private CameraManager cameraManager = null;
		private InputController Input = null;
		private ContactNode contactNode;
		
		public GameScene ()
		{
			this.Camera.SetViewFromViewport ();
			
			// output FPS benchmark to console
			// Scheduler.Instance.ScheduleUpdateForTarget (new FPSBenchmarkNode(), 2, false);
			
			Input = new InputController ();
			Scheduler.Instance.ScheduleUpdateForTarget (Input, 2, false);
			
			var fireNode = new FireNode ();
			Scheduler.Instance.ScheduleUpdateForTarget (fireNode, 2, false);
			cameraManager = new CameraManager (this.Camera2D);
			playerNode = new PlayerNode () {cameraManager = cameraManager, Input = Input, fireNode = fireNode};

			contactNode = new ContactNode () { cameraManager = cameraManager, playerNode = playerNode };

			AddChild (new StaticBackground ());
			AddChild (new BackgroundNode ());
			AddChild (playerNode);
			AddChild (fireNode);
			AddChild (contactNode);

			// blockers
			{
				SpriteUV [] spriteBlock = new SpriteUV[10];
				Texture2D texture;
				TextureInfo textureInfo;
				texture = new Texture2D ("/Application/Assets/images/fireleaf_one.png", false);
				textureInfo = new TextureInfo (texture);
				this.RegisterDisposeOnExit (textureInfo);

				for(int i = 0; i < 5; i++){
					spriteBlock[i] = new SpriteUV(textureInfo);
					spriteBlock[i].Quad.S = textureInfo.TextureSizef;
					spriteBlock[i].CenterSprite(new Vector2(0.65f, 0.5f));
					spriteBlock[i].Position = new Vector2(contactNode.blockPosition[i].X, contactNode.blockPosition[i].Y);;
					AddChild (spriteBlock[i]);

				}
			}
			
			ScheduleUpdate (0);
		}

		public override void Update (float dt)
		{
			base.Update (dt);
			
			if (Input.getButtonCounter () > 0) {
				playerNode.TransformationStart ();
			}
		}
		
	}
}
