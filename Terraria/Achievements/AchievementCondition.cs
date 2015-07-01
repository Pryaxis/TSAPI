using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace Terraria.Achievements
{
	[JsonObject(MemberSerialization.OptIn)]
	public abstract class AchievementCondition
	{
		public readonly string Name;

		protected IAchievementTracker _tracker;

		[JsonProperty("Completed")]
		private bool _isCompleted;

		public bool IsCompleted
		{
			get
			{
				return this._isCompleted;
			}
		}

		protected AchievementCondition(string name)
		{
			this.Name = name;
		}

		public virtual void Clear()
		{
			this._isCompleted = false;
		}

		public virtual void Complete()
		{
			if (this._isCompleted)
			{
				return;
			}
			this._isCompleted = true;
			if (this.OnComplete != null)
			{
				this.OnComplete(this);
			}
		}

		protected virtual IAchievementTracker CreateAchievementTracker()
		{
			return null;
		}

		public IAchievementTracker GetAchievementTracker()
		{
			if (this._tracker == null)
			{
				this._tracker = this.CreateAchievementTracker();
			}
			return this._tracker;
		}

		public virtual void Load(JObject state)
		{
			this._isCompleted = (bool)state["Completed"];
		}

		public event AchievementCondition.AchievementUpdate OnComplete;

		public delegate void AchievementUpdate(AchievementCondition condition);
	}
}