using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;


namespace Transwarmer
{
	public class PlayerNode : Node
	{
		public float position;
		public CameraManager cameraManager;
		public InputController Input;
		
		private SpriteAnimation sprite;
		
		public PlayerNode ()
		{
			
			sprite = new SpriteAnimation(
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			sprite.sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 0.5f);
			this.position = 272;
			sprite.Position = new Vector2(128, this.position);
			sprite.SetRotation(90);
			sprite.type = SpriteAnimation.AnimationType.Serial;
			sprite.PlayAnimation();

			AddChild(sprite);
			
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			position += 100.0f * dt;
			cameraManager.OnPlayerPositionChanged (position);
			
			
			
			switch( Input.getState() )
			{
			case InputController.CharacterState.Shrink:
				sprite.isReviece = false;
				break;
			case InputController.CharacterState.Stretch:
				sprite.isReviece = true;
				break;
			}
		}
	}
}
