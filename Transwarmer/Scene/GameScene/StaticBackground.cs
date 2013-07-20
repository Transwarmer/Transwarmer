using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Transwarmer
{
	public class StaticBackground : Node
	{
		public StaticBackground ()
		{
			var texture = new Texture2D ("/Application/Assets/background/background.jpg", false);
			var textureInfo = new TextureInfo (texture);
			var sprite = new SpriteUV (textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			
			AddChild (sprite);
			
			Camera = new Camera2D (Director.Instance.GL, Director.Instance.DrawHelpers);
			Camera.SetViewFromViewport ();
		}
	}
}

