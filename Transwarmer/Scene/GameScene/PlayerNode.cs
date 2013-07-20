using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;


namespace Transwarmer
{
	public class PlayerNode : Node
	{
		public PlayerNode ()
		{
			var sprite = new SpriteAnimation(
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			sprite.sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 0.5f);
			sprite.Position = new Vector2(128, 272);
			sprite.SetRotation(90);
			sprite.PlayAnimation();

			AddChild(sprite);
		}
	}
}