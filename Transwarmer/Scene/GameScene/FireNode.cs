using System;
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
		
		public FireNode ()
		{
			sprite = new SpriteAnimation ("/Application/Assets/images/unified_fire.png",
			                              "Application/Assets/images/unified_fire.xml");
			sprite.sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 0.5f);
			sprite.Position = new Vector2(100, 272);
			sprite.SetRotation(90);
			sprite.type = SpriteAnimation.AnimationType.Serial;
			sprite.PlayAnimation();
			AddChild(sprite);
			
			fireBgm = new Bgm ("/Application/Assets/sound/fire.mp3");
			fireBgmPlayer = fireBgm.CreatePlayer();
			fireBgmPlayer.Loop = true;
			fireBgmPlayer.Play ();
		}
	}
}

