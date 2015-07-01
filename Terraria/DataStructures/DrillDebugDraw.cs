using Microsoft.Xna.Framework;
using System;

namespace Terraria.DataStructures
{
	public struct DrillDebugDraw
	{
		public Vector2 point;

		public Color color;

		public DrillDebugDraw(Vector2 p, Color c)
		{
			this.point = p;
			this.color = c;
		}
	}
}