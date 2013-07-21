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
		private int spritesCount = 20;
		private int spritesIndex = 0;
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
			
			sprites = new SpriteAnimation[spritesCount];
			
			//Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
			
			sprites[0] = generateSprite(spriteWidth);
			AddChild(sprites[0]);
		}
		
		private SpriteAnimation generateSprite (float position)
		{
			var sprite = new SpriteAnimation ("/Application/Assets/images/unified_fireB.png",
			                              "Application/Assets/images/unified_fireB.xml");
			sprite.sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 0.5f);
			sprite.Position = new Vector2(position, 272);
			sprite.SetRotation(90);
			sprite.type = SpriteAnimation.AnimationType.Pingpong;
			sprite.PlayAnimation();
			return sprite;
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			float fireCount = fireFrontLine / spriteWidth;
			if (fireCount > spritesIndex) {
				RemoveChild(sprites[spritesIndex], false);
				spritesIndex--;
				if (spritesIndex < 0) {
					spritesIndex = 0;
				}
			} else if (fireCount < spritesCount) {
				spritesIndex++;
				if (spritesIndex < spritesCount) {
					sprites[spritesIndex] = generateSprite(spriteWidth);
					AddChild (sprites[spritesIndex]);
				} else {
					spritesIndex = spritesCount - 1;
				}
			}
		}
	}
}
