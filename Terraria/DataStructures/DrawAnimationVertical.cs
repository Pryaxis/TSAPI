using XNA;
using System;
using Terraria;

namespace Terraria.DataStructures
{
	public class DrawAnimationVertical : DrawAnimation
	{
		public DrawAnimationVertical(int ticksperframe, int frameCount)
		{
			this.Frame = 0;
			this.FrameCounter = 0;
			this.FrameCount = frameCount;
			this.TicksPerFrame = ticksperframe;
		}

		public override Rectangle GetFrame()
		{
			return Rectangle.Empty;
		}

		public override void Update()
		{
			DrawAnimationVertical drawAnimationVertical = this;
			int frameCounter = drawAnimationVertical.FrameCounter + 1;
			int num = frameCounter;
			drawAnimationVertical.FrameCounter = frameCounter;
			if (num >= this.TicksPerFrame)
			{
				this.FrameCounter = 0;
				DrawAnimationVertical drawAnimationVertical1 = this;
				int frame = drawAnimationVertical1.Frame + 1;
				int num1 = frame;
				drawAnimationVertical1.Frame = frame;
				if (num1 >= this.FrameCount)
				{
					this.Frame = 0;
				}
			}
		}
	}
}