using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Terraria;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	internal class CustomFloatCondition : AchievementCondition
	{
		[JsonProperty("Value")]
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

		public override void Load(JObject state)
		{
			base.Load(state);
			this._value = (float)((float)state["Value"]);
			if (this._tracker != null)
			{
				((ConditionFloatTracker)this._tracker).SetValue(this._value, false);
			}
		}
	}
}