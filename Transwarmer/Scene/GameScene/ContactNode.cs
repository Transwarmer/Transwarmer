using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core;

namespace Transwarmer
{
	public class ContactNode : Node
	{
		public Vector2 playerPosition;
		public PlayerNode playerNode;
		public CameraManager cameraManager;

		public Vector2 blockPosition = new Vector2(500, 250);
		public const float blockR = 64.0f;
		public const float playerR = 64.0f;

		public ContactNode ()
		{
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
		}

		public override void Update (float dt)
		{
			base.Update (dt);
			//playerPosition.X = playerNode.sprite.Position.X;
			//playerPosition.Y = cameraManager.getCameraPosition();
			playerPosition.X = cameraManager.getCameraPosition();
			playerPosition.Y = playerNode.warmSprite.sprite.Position.Y;
			{
				Vector2 disvec = playerPosition - blockPosition;
				float distance = disvec.Length();//playerPosition.Distance(blockPosition);
				if(distance < (blockR + playerR)){
					Vector2 direction =  playerPosition - blockPosition;
					direction = direction / direction.Length();
					//playerNode.warmSprite.Position += direction;
					playerNode.warmSprite.sprite.Position.X += direction.X;
					playerNode.warmSprite.sprite.Position.Y += direction.Y;
				}
				Console.WriteLine("player:" + playerPosition.X + " " + playerPosition.Y);
				Console.WriteLine("sprite:" + playerNode.warmSprite.sprite.Position.X + " " + playerNode.warmSprite.sprite.Position.Y);
				//Console.WriteLine("distance:" + distance);
			}
		}
	}
}

