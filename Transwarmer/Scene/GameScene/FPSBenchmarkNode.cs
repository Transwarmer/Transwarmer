using System;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{
	public class FPSBenchmarkNode : Node
	{
		public FPSBenchmarkNode ()
		{
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			Console.WriteLine (1.0f / dt);
		}
	}
}

