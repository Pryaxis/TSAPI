using Microsoft.Xna.Framework;
using System;

namespace Terraria.Graphics
{
	public struct vertexColors
	{
		public Color TopLeftColor;

		public Color TopRightColor;

		public Color bottomLeftColor;

		public Color BottomRightColor;

		public vertexColors(Color color)
		{
			this.TopLeftColor = color;
			this.TopRightColor = color;
			this.BottomRightColor = color;
			this.bottomLeftColor = color;
		}

		public vertexColors(Color topLeft, Color topRight, Color bottomRight, Color bottomLeft)
		{
			this.TopLeftColor = topLeft;
			this.TopRightColor = topRight;
			this.bottomLeftColor = bottomLeft;
			this.BottomRightColor = bottomRight;
		}
	}
}