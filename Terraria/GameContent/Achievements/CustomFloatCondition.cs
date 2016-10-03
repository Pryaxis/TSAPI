using System;
using Terraria;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	public class CustomFloatCondition : AchievementCondition
	{
		private float _value;

		private float _maxValue;

		public float Value
		{
			get
			{
				return this._value;
			}
			set
			{
				float single = Utils.Clamp<float>(value, 0f, this._maxValue);
				if (this._tracker != null)
				{
					((ConditionFloatTracker)this._tracker).SetValue(single, true);
				}
				this._value = single;
				if (this._value == this._maxValue)
				{
					this.Complete();
				}
			}
		}

		private CustomFloatCondition(string name, float maxValue) : base(name)
		{
			this._maxValue = maxValue;
			this._value = 0f;
		}

		public override void Clear()
		{
			this._value = 0f;
			base.Clear();
		}

		public static AchievementCondition Create(string name, float maxValue)
		{
			return new CustomFloatCondition(name, maxValue);
		}

		protected override IAchievementTracker CreateAchievementTracker()
		{
			return new ConditionFloatTracker(this._maxValue);
		}
	}
}