using System;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{ 
	public class Splite_Scene_Test : Scene
	{
		public SpliteAnimation splite;
		  
		public Splite_Scene_Test ()
		{ 
			splite = new SpliteAnimation(
				"Application/Assets/images/unified_texture.png", 
				"Application/Assets/images/unified_texture.xml");
			
			AddChild( splite);
			
			splite.PlayAnimation(0.01f);
		}
	}
}

