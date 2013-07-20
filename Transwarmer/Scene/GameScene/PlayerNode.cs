using System;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class PlayerNode : Node
	{
		public PlayerNode ()
		{
			var sprite = new SpliteAnimation(
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			AddChild(sprite);
			
			sprite.PlayAnimation(0.01f);
		}
	}
}

