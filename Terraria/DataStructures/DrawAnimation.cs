using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.DataStructures
{
	public class DrawAnimation
	{
		public int Frame;

		public int FrameCount;

		public int TicksPerFrame;

		public int FrameCounter;

		public DrawAnimation()
		{
		}

		public virtual Rectangle GetFrame(Texture2D texture)
		{
			return texture.Frame(1, 1, 0, 0);
		}

		public virtual void Update()
		{
		}
	}
}