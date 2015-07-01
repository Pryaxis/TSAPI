using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ShapeRunner : GenShape
	{
		private float _startStrength;

		private int _steps;

		private Vector2 _startVelocity;

		public ShapeRunner(float strength, int steps, Vector2 velocity)
		{
			this._startStrength = strength;
			this._steps = steps;
			this._startVelocity = velocity;
		}

		public override bool Perform(Point origin, GenAction action)
		{
			float single = (float)this._steps;
			float single1 = (float)this._steps;
			double num = (double)this._startStrength;
			Vector2 vector2 = new Vector2((float)origin.X, (float)origin.Y);
			Vector2 vector21 = (this._startVelocity == Vector2.Zero ? Utils.RandomVector2(GenBase._random, -1f, 1f) : this._startVelocity);
			while (single > 0f && num > 0)
			{
				num = (double)(this._startStrength * (single / single1));
				single = single - 1f;
				int num1 = Math.Max(1, (int)((double)vector2.X - num * 0.5));
				int num2 = Math.Max(1, (int)((double)vector2.Y - num * 0.5));
				int num3 = Math.Min(GenBase._worldWidth, (int)((double)vector2.X + num * 0.5));
				int num4 = Math.Min(GenBase._worldHeight, (int)((double)vector2.Y + num * 0.5));
				for (int i = num1; i < num3; i++)
				{
					for (int j = num2; j < num4; j++)
					{
						if ((double)(Math.Abs((float)i - vector2.X) + Math.Abs((float)j - vector2.Y)) < num * 0.5 * (1 + (double)GenBase._random.Next(-10, 11) * 0.015))
						{
							base.UnitApply(action, origin, i, j, new object[0]);
						}
					}
				}
				int num5 = (int)(num / 50) + 1;
				single = single - (float)num5;
				vector2 = vector2 + vector21;
				for (int k = 0; k < num5; k++)
				{
					vector2 = vector2 + vector21;
					vector21 = vector21 + Utils.RandomVector2(GenBase._random, -0.5f, 0.5f);
				}
				vector21 = vector21 + Utils.RandomVector2(GenBase._random, -0.5f, 0.5f);
				vector21 = Vector2.Clamp(vector21, -Vector2.One, Vector2.One);
			}
			return true;
		}
	}
}