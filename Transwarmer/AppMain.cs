using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class AppMain
	{	
		public static void Main (string[] args)
		{
			Initialize ();
			var initialScene = new TitleScene();
			
			Director.Instance.RunWithScene (initialScene);
		}
		
		public static void Initialize ()
		{
			Director.Initialize();
		}
	}
}
