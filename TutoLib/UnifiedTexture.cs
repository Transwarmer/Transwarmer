
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Tutorial.Utility
{

	public class UnifiedTextureInfo
	{
		public float u0;
		public float v0;
		public float u1;
		public float v1;
		public float w;
		public float h;
		
		public UnifiedTextureInfo(float u0, float v0, float u1, float v1, float w, float h)
		{
			this.u0=u0;
			this.v0=v0;
			this.u1=u1;
			this.v1=v1;
			this.w=w;
			this.h=h;
		}
	}
	
	public class UnifiedTexture
	{
		/// <summary>
		/// Gets the dictionary texture info.
		/// </summary>
		/// <returns>
		/// The dictionary of texture info.
		/// </returns>
		/// <param name='xmlFilename'>
		/// Xml filename.
		/// </param>
		static public Dictionary<string, UnifiedTextureInfo>　GetDictionaryTextureInfo(string xmlFilename)
		{
			Dictionary<string, UnifiedTextureInfo> dicTextureInfo = new Dictionary<string, UnifiedTextureInfo>();
			
			try
			{
				XDocument doc = XDocument.Load(xmlFilename);
				
				
				XElement root= doc.Element("root");
				
				//@e Get the size of the whole texture.
				//@j テクスチャ全体の大きさを取得する。
				var elementInfo = root.Element("info");
				float textureWidth=float.Parse(elementInfo.Attribute("w").Value);
				float textureHeight=float.Parse(elementInfo.Attribute("h").Value);
				
				Console.WriteLine(textureWidth+","+textureHeight);
				
				float x,y,w,h;
				
				foreach( var element in root.Descendants("texture"))
				{
					Console.WriteLine("texture "+element.Attribute("filename").Value);
					
					x=float.Parse(element.Attribute("x").Value);
					y=float.Parse(element.Attribute("y").Value);
					w=float.Parse(element.Attribute("w").Value);
					h=float.Parse(element.Attribute("h").Value);

					// Convert to UV.
					dicTextureInfo.Add(element.Attribute("filename").Value, 
					    new UnifiedTextureInfo(
							x/textureWidth,	y/textureHeight,
							(x+w)/textureWidth,	(y+h)/textureHeight,
							w,	h
						)
					 );
				}
			}
			catch (Exception e)
			{
			    Console.Error.WriteLine(e.Message);
			    Environment.Exit(1);
			}
			
			return dicTextureInfo;
		}
	}

}

