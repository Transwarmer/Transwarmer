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

		//public Vector2 blockPosition = new Vector2(30, 250);
		public Vector2 [] blockPosition = new Vector2[10];
		public const float blockR = 64.0f;
		public const float playerR = 64.0f;

		public ContactNode ()
		{
			blockPosition[0] = new Vector2(900,100);
			blockPosition[1] = new Vector2(1300,400);
			blockPosition[2] = new Vector2(1700,200);
			blockPosition[3] = new Vector2(2100,272);
			blockPosition[4] = new Vector2(2600,400);
			blockPosition[5] = new Vector2(900,400);
			blockPosition[6] = new Vector2(900,400);
			blockPosition[7] = new Vector2(900,400);
			blockPosition[8] = new Vector2(900,400);
			blockPosition[9] = new Vector2(900,400);
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
		}

		public override void Update (float dt)
		{
			base.Update (dt);
			//playerPosition.X = playerNode.sprite.Position.X;
			//playerPosition.Y = cameraManager.getCameraPosition();
			playerPosition.X = cameraManager.getCameraPosition() + 600.0f;
			playerPosition.Y = playerNode.warmSprite.sprite.Position.Y;
			for(int i = 0; i < 5; i++){
				Vector2 disvec = playerPosition - blockPosition[i];
				float distance = disvec.Length();//playerPosition.Distance(blockPosition);
				if(distance < (blockR + playerR)){
					Vector2 direction =  playerPosition - blockPosition[i];
					direction = direction / direction.Length();
					//playerNode.warmSprite.Position += direction;
					playerNode.warmSprite.Position += direction;
				}
				//Console.WriteLine("player:" + playerPosition.X + " " + playerPosition.Y);
				//Console.WriteLine("sprite:" + playerNode.warmSprite.sprite.Position.X + " " + playerNode.warmSprite.sprite.Position.Y);
				//Console.WriteLine("distance:" + distance);
			}
		}
	}
}

