using System;

namespace Terraria.Achievements
{
	public interface IAchievementTracker
	{
		void Clear();

		TrackerType GetTrackerType();

		void Load();

		void ReportAs(string name);
	}
}