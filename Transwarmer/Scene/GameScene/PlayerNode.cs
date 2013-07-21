using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core.Input;

namespace Transwarmer
{
	public class PlayerNode : Node
	{
		public float position;
		public CameraManager cameraManager;
		public InputController Input;
		public bool transformed = false;
		private SpriteAnimation warmSprite;
		private SpriteAnimation pupaSprite;
		private float angle = 0;
		
		public PlayerNode ()
		{
			warmSprite = new SpriteAnimation (
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			warmSprite.sprite.Center = new Sce.PlayStation.Core.Vector2 (0.5f, 1.0f);
			this.position = 272;
			warmSprite.Position = new Vector2 (300, this.position);
			warmSprite.SetRotation (90);
			warmSprite.type = SpriteAnimation.AnimationType.Serial;
			warmSprite.PlayAnimation ();

			AddChild (warmSprite);
			
						
			pupaSprite = new SpriteAnimation (
				"Application/Assets/images/unified_Butterfly.png", 
				"Application/Assets/images/unified_Butterfly.xml");
			
			warmSprite.SetRotation (90);
			
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			if (!transformed) {
				MoveWorm (dt);
			} else {
				Transforming ();
			}
		}
		
		private void MoveWorm (float dt)
		{
			cameraManager.OnPlayerPositionChanged (position);
			DebugDrawTransform ();
			
			switch (Input.getState ()) {
			case InputController.CharacterState.Shrink:
				if (warmSprite.isPlayed == false) {
					
					var v2 = warmSprite.Position.Multiply (warmSprite.dir2Rot (angle));
					position += 90.0f * dt;
					
					warmSprite.Position += new Vector2 (0, v2.X) * dt;
				} else {
					angle += GamePad.GetData (0).AnalogRightY;
					
					if (angle < -30)
						angle = -30;
					if (angle > 30)
						angle = 30;
					
					warmSprite.SetRotation (90 + angle);
				}
				warmSprite.isReviece = false;
				break;
				
			case InputController.CharacterState.Stretch:
				
				warmSprite.isReviece = true;
				break;
			}
		}
		
		public void TransformationStart ()
		{
			if (transformed)
				return;
			
			transformed = true;
			pupaSprite.Position = warmSprite.Position;
			
			pupaSprite.SetRotation (90);
			pupaSprite.PlayAnimation ();
			pupaSprite.sprite.Center = new Sce.PlayStation.Core.Vector2 (0.5f, 1.5f);
			
			AddChild (pupaSprite);
			RemoveChild (warmSprite, true);
			System.Console.WriteLine ("call");
		}
		
		private void Transforming ()
		{
			if (Input.getButtonCounter () > 5) {
				System.Console.WriteLine ("clear");
			}
		}
	}
}