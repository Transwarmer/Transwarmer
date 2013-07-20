using System;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{ 
	public class Sprite_Scene_Test : Scene
	{
		public SpriteAnimation sprite;
		  
		public Sprite_Scene_Test ()
		{ 
			sprite = new SpriteAnimation(
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			AddChild(sprite);
			
			sprite.PlayAnimation(0.01f);
		}
	}
}

