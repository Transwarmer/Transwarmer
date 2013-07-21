using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class FireNode : Node
	{
		private SpriteAnimation sprite;
		private Bgm fireBgm;
		private BgmPlayer fireBgmPlayer;
		private float spriteWidth = 100.0f;
		
		public float fireFrontLine = 0.0f;
		private SpriteUV firewallSprite;
		
		public FireNode ()
		{	
			fireBgm = new Bgm ("/Application/Assets/sound/fire.mp3");
			fireBgmPlayer = fireBgm.CreatePlayer();
			fireBgmPlayer.Loop = true;
			fireBgmPlayer.Play ();
			
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
			
			generateFirewallSprite ();
			generateSprite(spriteWidth, 0);
			AddChild(sprite);
		}
		
		private void generateFirewallSprite ()
		{
			var texture = new Texture2D ("/Application/Assets/images/fireWall.png", false);
			var textureInfo = new TextureInfo (texture);
			firewallSprite = new SpriteUV (textureInfo);
			float spriteWidth = 500.0f;
			float screenHeight = 544.0f;
			float spriteHeight = screenHeight;
			firewallSprite.Quad = new TRS (new Bounds2 (new Vector2 (-352.0f, 0.0f),
			                                    new Vector2 (fireFrontLine + spriteWidth - 352.0f, spriteHeight)));
			firewallSprite.BlendMode = BlendMode.Additive;
			AddChild (firewallSprite);
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
			fireFrontLine += 30.0f * dt;
			sprite.Position = new Vector2(fireFrontLine, 272);
			firewallSprite.Quad.T = firewallSprite.Quad.T.Add (new Vector2 (30.0f*dt, 0.0f));
		}
	}
}
