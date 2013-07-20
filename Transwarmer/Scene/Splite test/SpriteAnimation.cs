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
		public enum AnimationType{
			Pingpong,
			Serial,
			loop
		}
		
		public AnimationType type = AnimationType.Pingpong;
		
		private static SpriteBuffer sbuffer;
		public SpriteB sprite;
		private Texture2D texture;
		private Dictionary<string, UnifiedTextureInfo> dicTextureInfo;
		public List<string> animationList = new List<string> ();
		private int currentTexture = 0;
		bool isReviece = false;
		
		public SpriteAnimation (string pngFilePath, string xmlFilePath)
		{
			texture = new Texture2D (pngFilePath, false);
			dicTextureInfo = UnifiedTexture.GetDictionaryTextureInfo (xmlFilePath);
			
			sbuffer = new SpriteBuffer (Director.Instance.GL.Context, dicTextureInfo.Count);
			
			animationList.AddRange (dicTextureInfo.Keys);
			animationList.Sort ();
			sprite = new SpriteB (dicTextureInfo [animationList [0]]);
		}
		
		public void PlayAnimation ()
		{
			ScheduleUpdate (0);
		}
		
		public void Stop ()
		{
			UnscheduleUpdate ();
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);

			switch(type)
			{
			case AnimationType.loop:
				Loop();
				break;
			case AnimationType.Pingpong:
				PingPong();
				break;
			case AnimationType.Serial:
				Serial();
				break;
			}
			
			var uti = dicTextureInfo [animationList [currentTexture]];
			sprite.SetTextureInfo (uti);
			
			sprite.Position = new Vector3 (Position.X, Position.Y, 0);
		}
		
		public void Loop()
		{
			if (!isReviece) {
				currentTexture ++;
				if (! (currentTexture < animationList.Count - 1)) {
					currentTexture = 0;
				}
			} else {
				currentTexture --;
				if (currentTexture <= 0)
					currentTexture = animationList.Count - 1;
			}
		}
		
		public void PingPong()
		{
			if (!isReviece) {
				currentTexture ++;
				if (! (currentTexture < animationList.Count - 1)) {
					isReviece = true;
				}
			} else {
				currentTexture --;
				if (currentTexture <= 0)
					isReviece = false;
			}
		}
		
		public void Serial()
		{
			if (!isReviece) {
				currentTexture ++;
				if (! (currentTexture < animationList.Count - 1)) {
					currentTexture = animationList.Count -1;
				}
			} else {
				currentTexture --;
				if (currentTexture < 0)
					currentTexture = 0;
			}
		}
		
		public void SetRotation(float angle)
		{
			sprite.Rotation = dir2Rot(angle);
		}
		public float dir2Rot (double angle)
		{
			return (float)(angle / 180 * System.Math.PI);
		}

		public override void Draw ()
		{
			base.Draw ();
			
			Director.Instance.GL.Context.SetTexture (0, texture);

			sbuffer.Clear ();
			sbuffer.Add (sprite);
			sbuffer.Render ();
		}
	}
}

