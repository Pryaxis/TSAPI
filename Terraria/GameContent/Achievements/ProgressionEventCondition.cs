using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	public class ProgressionEventCondition : AchievementCondition
	{
		private const string Identifier = "PROGRESSION_EVENT";

		private static Dictionary<int, List<ProgressionEventCondition>> _listeners;

		private static bool _isListenerHooked;

		private int[] _eventIDs;

		static ProgressionEventCondition()
		{
			ProgressionEventCondition._listeners = new Dictionary<int, List<ProgressionEventCondition>>();
			ProgressionEventCondition._isListenerHooked = false;
		}

		private ProgressionEventCondition(int eventID) : base(string.Concat("PROGRESSION_EVENT_", eventID))
		{
			this._eventIDs = new int[] { eventID };
			ProgressionEventCondition.ListenForPickup(this);
		}

		private ProgressionEventCondition(int[] eventIDs) : base(string.Concat("PROGRESSION_EVENT_", eventIDs[0]))
		{
			this._eventIDs = eventIDs;
			ProgressionEventCondition.ListenForPickup(this);
		}

		public static ProgressionEventCondition Create(params int[] eventIDs)
		{
			return new ProgressionEventCondition(eventIDs);
		}

		public static ProgressionEventCondition Create(int eventID)
		{
			return new ProgressionEventCondition(eventID);
		}

		public static ProgressionEventCondition[] CreateMany(params int[] eventIDs)
		{
			ProgressionEventCondition[] progressionEventCondition = new ProgressionEventCondition[(int)eventIDs.Length];
			for (int i = 0; i < (int)eventIDs.Length; i++)
			{
				progressionEventCondition[i] = new ProgressionEventCondition(eventIDs[i]);
			}
			return progressionEventCondition;
		}

		private static void ListenForPickup(ProgressionEventCondition condition)
		{
			if (!ProgressionEventCondition._isListenerHooked)
			{
				AchievementsHelper.OnProgressionEvent += new AchievementsHelper.ProgressionEventEvent(ProgressionEventCondition.ProgressionEventListener);
				ProgressionEventCondition._isListenerHooked = true;
			}
			for (int i = 0; i < (int)condition._eventIDs.Length; i++)
			{
				if (!ProgressionEventCondition._listeners.ContainsKey(condition._eventIDs[i]))
				{
					ProgressionEventCondition._listeners[condition._eventIDs[i]] = new List<ProgressionEventCondition>();
				}
				ProgressionEventCondition._listeners[condition._eventIDs[i]].Add(condition);
			}
		}

		private static void ProgressionEventListener(int eventID)
		{
			if (ProgressionEventCondition._listeners.ContainsKey(eventID))
			{
				foreach (ProgressionEventCondition item in ProgressionEventCondition._listeners[eventID])
				{
					item.Complete();
				}
			}
		}
	}
}