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
		
		private SpriteAnimation sprite;
		private float angle = 0;
		
		public PlayerNode ()
		{
			sprite = new SpriteAnimation(
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			sprite.sprite.Center = new Sce.PlayStation.Core.Vector2(0.5f, 1.0f);
			this.position = 272;
			sprite.Position = new Vector2(300, this.position);
			sprite.SetRotation(90);
			sprite.type = SpriteAnimation.AnimationType.Serial;
			sprite.PlayAnimation();

			AddChild(sprite);
			
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			cameraManager.OnPlayerPositionChanged (position);
					DebugDrawTransform();
			
			switch( Input.getState() )
			{
			case InputController.CharacterState.Shrink:
				if( sprite.isPlayed == false){
					
					var v2 = sprite.Position.Multiply( sprite.dir2Rot( angle ) );
					position += 90.0f * dt ;
					
					sprite.Position += new Vector2( 0, v2.X) * dt ;
				}else{
					angle += GamePad.GetData(0).AnalogRightY;
					
					if( angle < -30) angle = -30;
					if( angle > 30 ) angle = 30;
					
					sprite.SetRotation( 90 + angle );
				}
				sprite.isReviece = false;
				break;
				
			case InputController.CharacterState.Stretch:
				
				if( sprite.isPlayed == false ){
				}
				
				sprite.isReviece = true;
				break;
			}
		}
	}
}