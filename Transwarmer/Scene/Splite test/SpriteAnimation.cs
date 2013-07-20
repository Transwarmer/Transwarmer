using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Tutorial.Utility;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
  
namespace Transwarmer
{
	public class SpriteAnimation : Node
	{
		
		private static SpriteBuffer sbuffer;
		public SpriteB sprite; 
	
		private Texture2D texture;
		private Dictionary<string, UnifiedTextureInfo> dicTextureInfo;
		
		public List<string> animationList = new List<string>();

		private static System.Threading.Timer timer;
		private int currentTexture = 0;
		
		bool isReviece = false;
		
		public SpriteAnimation (string pngFilePath, string xmlFilePath)
		{
			texture = new Texture2D(pngFilePath, false);
			dicTextureInfo = UnifiedTexture.GetDictionaryTextureInfo(xmlFilePath);
			
			sbuffer = new SpriteBuffer( Director.Instance.GL.Context, dicTextureInfo.Count);
			
			animationList.AddRange( dicTextureInfo.Keys );
			animationList.Sort();
			sprite = new SpriteB( dicTextureInfo[animationList[0]] );
		}
		
		
		public void PlayAnimation(float interval)
		{
			if( timer != null){
				timer.Dispose();
				timer = null; 
			}
			
			timer = new System.Threading.Timer( (state) => 
			{
				if( !isReviece ) {
					currentTexture ++;
					if( ! (currentTexture < animationList.Count )){
						isReviece = true;
					}
				}else{
					currentTexture --;
					isReviece = !( animationList.Count < 0 );
					if( currentTexture <= 0 )
						isReviece = false;
				}

				Console.WriteLine(currentTexture);
				
				var uti = dicTextureInfo[animationList[currentTexture] ];
				sprite.SetTextureInfo(uti);
				
			}, null, 0, (int)(interval * 1000));
		}
		
		public void Stop()
		{
			timer.Dispose();
		} 
		
		public override void Draw ()
		{
			base.Draw ();
			Director.Instance.GL.Context.SetTexture(0, texture);

			sbuffer.Clear();
			sbuffer.Add(sprite);
			sbuffer.Render();
		}
	}
}

