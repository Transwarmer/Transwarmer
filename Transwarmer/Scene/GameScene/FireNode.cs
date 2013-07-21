using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class FireNode : Node
	{
		private SpriteAnimation sprite;
		private Bgm fireBgm;
		private BgmPlayer fireBgmPlayer;
		private float spriteWidth = 100.0f;
		
		public float fireFrontLine = 0.0f;
		
		public FireNode ()
		{	
			fireBgm = new Bgm ("/Application/Assets/sound/fire.mp3");
			fireBgmPlayer = fireBgm.CreatePlayer();
			fireBgmPlayer.Loop = true;
			fireBgmPlayer.Play ();
			
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
			
			generateSprite(spriteWidth, 0);
			AddChild(sprite);
		}
		
		private void generateSprite (float position, int index)
		{
			sprite = new SpriteAnimation ("/Application/Assets/images/unified_fireB.png",
			                              "Application/Assets/images/unified_fireB.xml");
			sprite.sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 0.5f);
			sprite.Position = new Vector2(position, 272);
			sprite.SetRotation(90);
			sprite.type = SpriteAnimation.AnimationType.Pingpong;
			sprite.PlayAnimation();
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			fireFrontLine += 10.0f * dt;
			sprite.Position = new Vector2(fireFrontLine, 272);
		}
	}
}
