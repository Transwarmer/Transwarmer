using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class FireNode : Node
	{
		private SpriteAnimation [] sprites;
		private int maxSprites = 5;
		private int spritesCount;
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
			
			//Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
			
			sprites = new SpriteAnimation[maxSprites];
			generateSprite(spriteWidth, 0);
			AddChild(sprites[0]);
			spritesCount = 1;
		}
		
		private void generateSprite (float position, int index)
		{
			sprites[index] = new SpriteAnimation ("/Application/Assets/images/unified_fireB.png",
			                              "Application/Assets/images/unified_fireB.xml");
			sprites[index].sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 0.5f);
			sprites[index].Position = new Vector2(position, 272);
			sprites[index].SetRotation(90);
			sprites[index].type = SpriteAnimation.AnimationType.Pingpong;
			sprites[index].PlayAnimation();
		}
	}
}
