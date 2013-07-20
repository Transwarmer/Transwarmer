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
		SpriteUV[] sprites;
		
		public BackgroundNode ()
		{
			Director.Instance.GL.Context.SetClearColor(1.0f, 1.0f, 1.0f, 0.0f);
			
			texture = new Texture2D ("/Application/Assets/images/haikei.png", false);
			TextureInfo textureInfo = new TextureInfo (texture);
			
			// fill screen with tree
			sprites = new SpriteUV[3];
			for (int i = 0; i < 3; i++) {
				sprites[i] = generateSprite(i * 800.0f, textureInfo);
				AddChild (sprites[i]);
			}
		}
		
		private SpriteUV generateSprite (float leftX, TextureInfo textureInfo)
		{
			var sprite = new SpriteUV (textureInfo);
			float spriteHeight = 800.0f;
			float spriteWidth = spriteHeight;
			float screenHeight = 544.0f;
			sprite.Quad = new TRS (new Bounds2 (new Vector2 (leftX, screenHeight / 2.0f - spriteHeight / 2.0f),
			                                    new Vector2 (leftX + spriteWidth, screenHeight / 2.0f + spriteHeight / 2.0f)));
			return sprite;
		}
	}
}
