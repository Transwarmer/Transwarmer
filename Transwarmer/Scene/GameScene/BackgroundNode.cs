using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class BackgroundNode : Node
	{
		Texture2D texture;
		SpriteUV[] spriteRing;
		int ringCount = 3;
		int ringIndex;
		TextureInfo textureInfo;
		float frontline = 0.0f;
		float spriteWidth = 700.0f;
		
		public BackgroundNode ()
		{
			texture = new Texture2D ("/Application/Assets/images/haikei.png", false);
			textureInfo = new TextureInfo (texture);
			
			// fill screen with tree
			spriteRing = new SpriteUV[ringCount];
			for (int i = 0; i < ringCount; i++) {
				spriteRing[i] = generateSprite(frontline);
				frontline+= spriteWidth;
				AddChild (spriteRing[i]);
			}
			ringIndex = 0;
			Scheduler.Instance.ScheduleUpdateForTarget (this, 2, false);
		}
		
		private SpriteUV generateSprite (float leftX)
		{
			var sprite = new SpriteUV (textureInfo);
			float spriteHeight = spriteWidth;
			float screenHeight = 544.0f;
			sprite.Quad = new TRS (new Bounds2 (new Vector2 (leftX, screenHeight / 2.0f - spriteHeight / 2.0f),
			                                    new Vector2 (leftX + spriteWidth, screenHeight / 2.0f + spriteHeight / 2.0f)));
			return sprite;
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			var cameraBounds = Parent.Camera.CalcBounds();
			Bounds2 spriteBounds = new Bounds2 ();
			spriteRing[ringIndex].GetContentWorldBounds(ref spriteBounds);
			
			float cameraFrontLine = cameraBounds.Min.X;
			float spriteFrontLine = spriteBounds.Max.X;
			if (spriteFrontLine < cameraFrontLine) {
				// remove unseen sprite
				RemoveChild (spriteRing[ringIndex], true);
				
				// add sprite to next of current sprites
				spriteRing[ringIndex] = generateSprite(frontline);
				AddChild (spriteRing[ringIndex]);
				
				frontline += spriteWidth;
				ringIndex++;
				ringIndex %= ringCount;
			}
		}
	}
}
