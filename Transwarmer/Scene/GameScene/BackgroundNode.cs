using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class BackgroundNode : Node
	{
		Texture2D backgroundTexture;
		
		public BackgroundNode ()
		{
			backgroundTexture = new Texture2D ("/Application/Assets/background/dummy_fullscreen.png", false);
		}
	}
}

