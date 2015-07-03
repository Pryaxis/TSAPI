using XNA;
using System;

namespace Terraria.World.Generation
{
	internal abstract class GenAction : GenBase
	{
		public GenAction NextAction;

		public ShapeData OutputData;

		private bool _returnFalseOnFailure = true;

		protected GenAction()
		{
		}

		public abstract bool Apply(Point origin, int x, int y, params object[] args);

		protected bool Fail()
		{
			return !this._returnFalseOnFailure;
		}

		public GenAction IgnoreFailures()
		{
			this._returnFalseOnFailure = false;
			return this;
		}

		public GenAction Output(ShapeData data)
		{
			this.OutputData = data;
			return this;
		}

		protected bool UnitApply(Point origin, int x, int y, params object[] args)
		{
			if (this.OutputData != null)
			{
				this.OutputData.Add(x - origin.X, y - origin.Y);
			}
			if (this.NextAction == null)
			{
				return true;
			}
			return this.NextAction.Apply(origin, x, y, args);
		}
	}
}