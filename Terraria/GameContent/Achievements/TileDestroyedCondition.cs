using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	internal class TileDestroyedCondition : AchievementCondition
	{
		private const string Identifier = "TILE_DESTROYED";

		private static Dictionary<ushort, List<TileDestroyedCondition>> _listeners;

		private static bool _isListenerHooked;

		private ushort[] _tileIds;

		static TileDestroyedCondition()
		{
			TileDestroyedCondition._listeners = new Dictionary<ushort, List<TileDestroyedCondition>>();
			TileDestroyedCondition._isListenerHooked = false;
		}

		private TileDestroyedCondition(ushort[] tileIds) : base(string.Concat("TILE_DESTROYED_", tileIds[0]))
		{
			this._tileIds = tileIds;
			TileDestroyedCondition.ListenForDestruction(this);
		}

		public static AchievementCondition Create(params ushort[] tileIds)
		{
			return new TileDestroyedCondition(tileIds);
		}

		private static void ListenForDestruction(TileDestroyedCondition condition)
		{
			if (!TileDestroyedCondition._isListenerHooked)
			{
				AchievementsHelper.OnTileDestroyed += new AchievementsHelper.TileDestroyedEvent(TileDestroyedCondition.TileDestroyedListener);
				TileDestroyedCondition._isListenerHooked = true;
			}
			for (int i = 0; i < (int)condition._tileIds.Length; i++)
			{
				if (!TileDestroyedCondition._listeners.ContainsKey(condition._tileIds[i]))
				{
					TileDestroyedCondition._listeners[condition._tileIds[i]] = new List<TileDestroyedCondition>();
				}
				TileDestroyedCondition._listeners[condition._tileIds[i]].Add(condition);
			}
		}

		private static void TileDestroyedListener(Player player, ushort tileId)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (TileDestroyedCondition._listeners.ContainsKey(tileId))
			{
				foreach (TileDestroyedCondition item in TileDestroyedCondition._listeners[tileId])
				{
					item.Complete();
				}
			}
		}
	}
}