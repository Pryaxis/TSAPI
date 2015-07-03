using XNA;
using System;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ShapeRoot : GenShape
	{
		private float _angle;

		private float _startingSize;

		private float _endingSize;

		private float _distance;

		public ShapeRoot(float angle, float distance = 10f, float startingSize = 4f, float endingSize = 1f)
		{
			this._angle = angle;
			this._distance = distance;
			this._startingSize = startingSize;
			this._endingSize = endingSize;
		}

		private bool DoRoot(Point origin, GenAction action, float angle, float distance, float startingSize)
		{
			float x = (float)origin.X;
			float y = (float)origin.Y;
			for (float i = 0f; i < distance * 0.85f; i = i + 1f)
			{
				float single = i / distance;
				float single1 = MathHelper.Lerp(startingSize, this._endingSize, single);
				x = x + (float)Math.Cos((double)angle);
				y = y + (float)Math.Sin((double)angle);
				angle = angle + (GenBase._random.NextFloat() - 0.5f + GenBase._random.NextFloat() * (this._angle - 1.57079637f) * 0.1f * (1f - single));
				angle = angle * 0.4f + 0.45f * MathHelper.Clamp(angle, this._angle - 2f * (1f - 0.5f * single), this._angle + 2f * (1f - 0.5f * single)) + MathHelper.Lerp(this._angle, 1.57079637f, single) * 0.15f;
				for (int j = 0; j < (int)single1; j++)
				{
					for (int k = 0; k < (int)single1; k++)
					{
						if (!base.UnitApply(action, origin, (int)x + j, (int)y + k, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		public override bool Perform(Point origin, GenAction action)
		{
			return this.DoRoot(origin, action, this._angle, this._distance, this._startingSize);
		}
	}
}