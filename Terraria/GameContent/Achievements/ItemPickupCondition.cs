using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	public class ItemPickupCondition : AchievementCondition
	{
		private const string Identifier = "ITEM_PICKUP";

		private static Dictionary<short, List<ItemPickupCondition>> _listeners;

		private static bool _isListenerHooked;

		private short[] _itemIds;

		static ItemPickupCondition()
		{
			ItemPickupCondition._listeners = new Dictionary<short, List<ItemPickupCondition>>();
			ItemPickupCondition._isListenerHooked = false;
		}

		private ItemPickupCondition(short itemId) : base(string.Concat("ITEM_PICKUP_", itemId))
		{
			this._itemIds = new short[] { itemId };
			ItemPickupCondition.ListenForPickup(this);
		}

		private ItemPickupCondition(short[] itemIds) : base(string.Concat("ITEM_PICKUP_", itemIds[0]))
		{
			this._itemIds = itemIds;
			ItemPickupCondition.ListenForPickup(this);
		}

		public static AchievementCondition Create(params short[] items)
		{
			return new ItemPickupCondition(items);
		}

		public static AchievementCondition Create(short item)
		{
			return new ItemPickupCondition(item);
		}

		public static AchievementCondition[] CreateMany(params short[] items)
		{
			AchievementCondition[] itemPickupCondition = new AchievementCondition[(int)items.Length];
			for (int i = 0; i < (int)items.Length; i++)
			{
				itemPickupCondition[i] = new ItemPickupCondition(items[i]);
			}
			return itemPickupCondition;
		}

		private static void ItemPickupListener(Player player, short itemId, int count)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (ItemPickupCondition._listeners.ContainsKey(itemId))
			{
				foreach (ItemPickupCondition item in ItemPickupCondition._listeners[itemId])
				{
					item.Complete();
				}
			}
		}

		private static void ListenForPickup(ItemPickupCondition condition)
		{
			if (!ItemPickupCondition._isListenerHooked)
			{
				AchievementsHelper.OnItemPickup += new AchievementsHelper.ItemPickupEvent(ItemPickupCondition.ItemPickupListener);
				ItemPickupCondition._isListenerHooked = true;
			}
			for (int i = 0; i < (int)condition._itemIds.Length; i++)
			{
				if (!ItemPickupCondition._listeners.ContainsKey(condition._itemIds[i]))
				{
					ItemPickupCondition._listeners[condition._itemIds[i]] = new List<ItemPickupCondition>();
				}
				ItemPickupCondition._listeners[condition._itemIds[i]].Add(condition);
			}
		}
	}
}