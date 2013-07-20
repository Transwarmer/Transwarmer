using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class BackgroundNode : Node
	{
		Texture2D texture;
		SpriteUV sprite;
		
		public BackgroundNode ()
		{
			Director.Instance.GL.Context.SetClearColor(0,0,0,0);
			
			texture = new Texture2D ("/Application/Assets/background/dummy_fullscreen.png", false);
			TextureInfo textureInfo = new TextureInfo (texture);
			sprite = new SpriteUV (textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			
			AddChild (sprite);
		}
	}
}

