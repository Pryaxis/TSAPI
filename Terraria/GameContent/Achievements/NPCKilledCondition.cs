using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	public class NPCKilledCondition : AchievementCondition
	{
		private const string Identifier = "NPC_KILLED";

		private static Dictionary<short, List<NPCKilledCondition>> _listeners;

		private static bool _isListenerHooked;

		private short[] _npcIds;

		static NPCKilledCondition()
		{
			NPCKilledCondition._listeners = new Dictionary<short, List<NPCKilledCondition>>();
			NPCKilledCondition._isListenerHooked = false;
		}

		private NPCKilledCondition(short npcId) : base(string.Concat("NPC_KILLED_", npcId))
		{
			this._npcIds = new short[] { npcId };
			NPCKilledCondition.ListenForPickup(this);
		}

		private NPCKilledCondition(short[] npcIds) : base(string.Concat("NPC_KILLED_", npcIds[0]))
		{
			this._npcIds = npcIds;
			NPCKilledCondition.ListenForPickup(this);
		}

		public static AchievementCondition Create(params short[] npcIds)
		{
			return new NPCKilledCondition(npcIds);
		}

		public static AchievementCondition Create(short npcId)
		{
			return new NPCKilledCondition(npcId);
		}

		public static AchievementCondition[] CreateMany(params short[] npcs)
		{
			AchievementCondition[] nPCKilledCondition = new AchievementCondition[(int)npcs.Length];
			for (int i = 0; i < (int)npcs.Length; i++)
			{
				nPCKilledCondition[i] = new NPCKilledCondition(npcs[i]);
			}
			return nPCKilledCondition;
		}

		private static void ListenForPickup(NPCKilledCondition condition)
		{
			if (!NPCKilledCondition._isListenerHooked)
			{
				AchievementsHelper.OnNPCKilled += new AchievementsHelper.NPCKilledEvent(NPCKilledCondition.NPCKilledListener);
				NPCKilledCondition._isListenerHooked = true;
			}
			for (int i = 0; i < (int)condition._npcIds.Length; i++)
			{
				if (!NPCKilledCondition._listeners.ContainsKey(condition._npcIds[i]))
				{
					NPCKilledCondition._listeners[condition._npcIds[i]] = new List<NPCKilledCondition>();
				}
				NPCKilledCondition._listeners[condition._npcIds[i]].Add(condition);
			}
		}

		private static void NPCKilledListener(Player player, short npcId)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (NPCKilledCondition._listeners.ContainsKey(npcId))
			{
				foreach (NPCKilledCondition item in NPCKilledCondition._listeners[npcId])
				{
					item.Complete();
				}
			}
		}
	}
}