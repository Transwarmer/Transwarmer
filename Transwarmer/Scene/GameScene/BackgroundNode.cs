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
		SpriteUV spritePrev;
		SpriteUV spriteNext;
		
		public BackgroundNode ()
		{
			Director.Instance.GL.Context.SetClearColor(0,0,0,0);
			
			texture = new Texture2D ("/Application/Assets/background/dummy_fullscreen.png", false);
			TextureInfo textureInfo = new TextureInfo (texture);
			
			spritePrev = new SpriteUV (textureInfo);
			spritePrev.Quad.S = textureInfo.TextureSizef;
			
			spriteNext = new SpriteUV (textureInfo);
			spriteNext.Quad.S = textureInfo.TextureSizef;
			spriteNext.Quad.T = new Vector2(-960.0f, 0.0f);
			
			AddChild (spritePrev);
			AddChild (spriteNext);
		}
	}
}

