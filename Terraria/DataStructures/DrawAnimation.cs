using XNA;
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

		public virtual Rectangle GetFrame()
		{
			return Rectangle.Empty;
		}

		public virtual void Update()
		{
		}
	}
}